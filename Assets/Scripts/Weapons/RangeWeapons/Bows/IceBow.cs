using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IceBow", menuName = "Assets/RangeWeapon/IceBow")]
public class IceBow : NormalBow
{
    public float effectDuration = 2f;
    
    public override void ApplyDebuff(ref AttackDetails attackDetails)
    {
        base.ApplyDebuff(ref attackDetails);

        attackDetails.freeze = true;
        Debug.Log("Freeze arrow");
    }

    public override void SpellEnter(Player player, PlayerSpellState playerSpellState)
    {
        base.SpellEnter(player, playerSpellState);
        if(spellCooldown + lastSpellTime <= Time.time) {
            lastSpellTime = Time.time;

            tempObj = Instantiate(spellEffect[0],player.transform.position, Quaternion.Euler(90f,0f,0f));
            tempObj.GetComponent<EffectController>().effectDuration = effectDuration;

            player.StateMachine.ChangeState(player.IdleState);

        }
        else {
            player.StateMachine.ChangeState(player.IdleState);
        }

        //perform animation maybe
    }

    public override void SpellExit(Player player, PlayerSpellState playerSpellState)
    {
        base.SpellExit(player, playerSpellState);
    }

    public override void SpellLogicUpdate(Player player, PlayerSpellState playerSpellState)
    {
        base.SpellLogicUpdate(player, playerSpellState);
    }

    public override void WeaponGizmos(Player player)
    {
        base.WeaponGizmos(player);
    }
}
