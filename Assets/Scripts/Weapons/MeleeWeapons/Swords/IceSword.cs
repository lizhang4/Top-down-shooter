using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IceSword", menuName = "Assets/MeleeWeapon/Swords/IceSword")]
public class IceSword : MeleeWeapon
{
    public float chargeDamageMultiplier = 3f;
    public float spellDuration = 2f;
    private bool chargeAttack = false;
    private int attackPhase = 0;
    private int initialHealth = 0;


    public override void AttackEnter(Player player, PlayerAttackState playerAttackState)
    {
        base.AttackEnter(player, playerAttackState);

        if(chargeAttack) {
            attackDetails.damageAmount = (int)(attackDetails.damageAmount * chargeDamageMultiplier);
            chargeAttack = false;
        }


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
        base.SpellEnter(player, playerSpellState);

        initialHealth = player.playerStats.currentHealth;
    }

    public override void SpellExit(Player player, PlayerSpellState playerSpellState)
    {
        base.SpellExit(player, playerSpellState);
    }

    public override void SpellLogicUpdate(Player player, PlayerSpellState playerSpellState)
    {
        base.SpellLogicUpdate(player, playerSpellState);

        if (spellDuration + playerSpellState.startTime > Time.time) {
            player.ImmuneDamageOn();
            if(player.GetHit()) {
                chargeAttack = true;
            }
            
        }
        else {
            player.ImmuneDamageOff();
            

            player.StateMachine.ChangeState(player.IdleState);
        }
    }

    public override void WeaponGizmos(Player player)
    {
        base.WeaponGizmos(player);
    }
}
