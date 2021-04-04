using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ThunderSword", menuName = "Assets/MeleeWeapon/Swords/ThunderSword")]
public class ThunderSword : MeleeWeapon
{
    public float dashDuration = 5f;
    public float dashSpeed = 25f;

    private Vector2 startPos;
    private Animator anim;
    private float attackDistance;




    public override void SpellEnter(Player player, PlayerSpellState playerSpellState)
    {
        attackDetails.damageAmount = spellDamage;
        tempObj = Instantiate(spellEffect[0], player.attackPoint);
        anim = tempObj.GetComponent<Animator>();
        anim.SetBool("Spell", true);

        player.SetVelocity(player.facingDirection, dashSpeed);
        attackDistance = dashDuration/dashDuration;

        Collider2D[] enemiesHit = Physics2D.OverlapCircleAll(player.attackPoint.position, attackDistance, whatIsDamagable);

        foreach (Collider2D enemy in enemiesHit) {
            enemy.transform.SendMessage("Damage", attackDetails);
        }
        

    }

    public override void SpellExit(Player player, PlayerSpellState playerSpellState)
    {
        anim.SetBool("Spell", false);
        Destroy(tempObj);
    }


    public override void SpellLogicUpdate(Player player, PlayerSpellState playerSpellState)
    {
        if(playerSpellState.startTime + dashDuration <= Time.time) {
            player.StateMachine.ChangeState(player.IdleState);
        }
        player.SetVelocity(player.facingDirection, dashSpeed);

    }

    public override void SpellAnimationTrigger(Player player, PlayerSpellState playerSpellState)
    {
        
    }
}
