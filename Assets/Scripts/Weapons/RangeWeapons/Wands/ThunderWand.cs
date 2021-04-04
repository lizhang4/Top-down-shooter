using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ThunderWand", menuName = "Assets/RangeWeapon/ThunderWand")]

public class ThunderWand : NormalWand
{
    public float spellRadius = 5f;
    public float offsetDistance = 2f;
    private Vector3 offsetDirection;
    private GameObject spellTempObj;
    // Spell
    public float teleportMaxDistance = 5f;



    public override void AttackEnter(Player player, PlayerAttackState playerAttackState)
    {
        base.AttackEnter(player, playerAttackState);
        //attackDetails.damageAmount = attackDamage;
    }

    public override void AttackLogicUpdate(Player player, PlayerAttackState playerAttackState)
    {
        base.AttackLogicUpdate(player, playerAttackState);
        // offsetDirection = player.facingDirection * offsetDistance; 
        // if(playerAttackState.attackInput) {
        //     if(lastAttackTime + (1/attackRate) <= Time.time){
        //         lastAttackTime = Time.time;
        //         Debug.Log("Thunder Wand Attack");
        //         //Spawn lightning
        //         Collider2D[] enemiesHit = Physics2D.OverlapCircleAll(player.attackPoint.position + offsetDirection, attackRadius, whatIsDamagable);
        
        //         foreach (Collider2D enemy in enemiesHit) {
        //             enemy.transform.SendMessage("Damage", attackDetails);
        //         }
        //     }
        // }
        // else {
        //     player.StateMachine.ChangeState(player.IdleState);
        // }
    }



    public override void SpellAnimationFinishTrigger(Player player, PlayerSpellState playerSpellState)
    {
        base.SpellAnimationFinishTrigger(player, playerSpellState);
    }

    public override void SpellAnimationTrigger(Player player, PlayerSpellState playerSpellState)
    {
        base.SpellAnimationTrigger(player, playerSpellState);
    }

    public override void SpellEnter(Player player, PlayerSpellState playerSpellState)
    {
        //base.SpellEnter(player, playerSpellState);

        attackDetails.damageAmount = spellDamage;


        if (lastSpellTime + spellCooldown <= Time.time) {
            lastSpellTime = Time.time;

            Debug.Log("World Position: "+ player.GetCursorPosition());
            Vector3 playerPos = player.transform.position;
            Vector3 teleportPos = player.GetCursorPosition();
            if(Mathf.Abs(Vector2.Distance(playerPos, teleportPos)) <= teleportMaxDistance) {
                Debug.Log("Teleport Pos:" + teleportPos);
                player.SetPosition(player.GetCursorPosition());
            }
            else {
                teleportPos = (Vector2)player.transform.position + player.facingDirection * teleportMaxDistance;
                Debug.Log("Teleport Pos:" + teleportPos);
                player.SetPosition(teleportPos);
            }

            spellTempObj = Instantiate(spellEffect[0],player.transform );
            Collider2D[] enemiesHit = Physics2D.OverlapCircleAll(player.transform.position, spellRadius, whatIsDamagable);

            foreach(Collider2D enemy in enemiesHit) {
                enemy.SendMessage("Damage", attackDetails);
            }

            player.StateMachine.ChangeState(player.IdleState);

        }
        else {
            player.StateMachine.ChangeState(player.IdleState);
        }

        
    }

    public override void SpellExit(Player player, PlayerSpellState playerSpellState)
    {
        //base.SpellExit(player, playerSpellState);
    }

    public override void SpellLogicUpdate(Player player, PlayerSpellState playerSpellState)
    {
        //base.SpellLogicUpdate(player, playerSpellState);
    }


    public override void WeaponGizmos(Player player)
    {
        base.WeaponGizmos(player);
        offsetDirection = player.facingDirection * offsetDistance; 

        Gizmos.DrawWireSphere(player.transform.position, spellRadius);

        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(player.transform.position, teleportMaxDistance);

    }
}
