using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ThunderBow", menuName = "Assets/RangeWeapon/ThunderBow")]

public class ThunderBow : NormalBow
{
    public float addedMoveSpeed;
    public float buffDuration;

    public float originalMoveSpeed;
    public override void ApplyDebuff(ref AttackDetails attackDetails)
    {
        base.ApplyDebuff(ref attackDetails);

        attackDetails.shock = true;
        Debug.Log("Thunder arrow");
    }

    public override void SpellEnter(Player player, PlayerSpellState playerSpellState)
    {
        base.SpellEnter(player, playerSpellState);

        originalMoveSpeed = player.playerData.moveSpeed;
        if (spellCooldown + lastSpellTime <= Time.time) {
            Debug.Log("SpeedBuff");
            player.StartCoroutine(player.MoveSpeedBuff(originalMoveSpeed+addedMoveSpeed, buffDuration, originalMoveSpeed));
            player.StateMachine.ChangeState(player.IdleState);
        }
        else {
            player.StateMachine.ChangeState(player.IdleState);
        }
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
