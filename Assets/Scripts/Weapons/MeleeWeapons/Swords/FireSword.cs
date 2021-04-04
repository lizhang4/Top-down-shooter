using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FireSword", menuName = "Assets/MeleeWeapon/Swords/FireSword")]
public class FireSword : MeleeWeapon
{
    public float spellDamageRate = 2f;
    private float spellLastDamageTime;
    public override void SpellAnimationFinishTrigger(Player player, PlayerSpellState playerSpellState)
    {
        base.SpellAnimationFinishTrigger(player, playerSpellState);

        //Destroy(tempObj);
        float time = Time.time - playerSpellState.startTime;
        Debug.Log("Time:"+ time);
        player.StateMachine.ChangeState(player.IdleState);
    }

    public override void SpellAnimationTrigger(Player player, PlayerSpellState playerSpellState)
    {
        base.SpellAnimationTrigger(player, playerSpellState);

        Collider2D[] enemiesHit = Physics2D.OverlapCircleAll(player.transform.position, spellRadius, whatIsDamagable);

        foreach (Collider2D enemy in enemiesHit) {
            enemy.transform.SendMessage("Damage", attackDetails);
        }
    }

    public override void AttackEnter(Player player, PlayerAttackState playerAttackState)
    {
        base.AttackEnter(player, playerAttackState);
        
        attackDetails.damageAmount = attackDamage;
        Collider2D[] enemiesHit = Physics2D.OverlapCircleAll(player.attackPoint.position, attackRadius, whatIsDamagable);
        
        foreach (Collider2D enemy in enemiesHit) {
            enemy.transform.SendMessage("Damage", attackDetails);
        }
    }

    public override void SpellLogicUpdate(Player player, PlayerSpellState playerSpellState)
    {
        base.SpellLogicUpdate(player, playerSpellState);

        if (spellLastDamageTime + 1/spellDamageRate < Time.time) {
            spellLastDamageTime = Time.time;

            Collider2D[] enemiesHit = Physics2D.OverlapCircleAll(player.transform.position, spellRadius, whatIsDamagable);
        
            foreach (Collider2D enemy in enemiesHit) {
                enemy.transform.SendMessage("Damage", attackDetails);
            }
        }
        


    }

    public override void SpellEnter(Player player, PlayerSpellState playerSpellState)
    {
        base.SpellEnter(player, playerSpellState);

        spellLastDamageTime = Time.time;
        attackDetails.damageAmount = spellDamage;
        tempObj = Instantiate(spellEffect[0], player.transform);
        
    }

    public override void SpellExit(Player player, PlayerSpellState playerSpellState)
    {
        base.SpellExit(player, playerSpellState);
    }

    public override void WeaponGizmos(Player player) {

        Gizmos.DrawWireSphere(player.attackPoint.position, attackRadius);
        Gizmos.DrawWireSphere(player.transform.position, spellRadius);
    }
}
