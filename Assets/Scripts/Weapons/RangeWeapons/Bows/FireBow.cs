using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FireBow", menuName = "Assets/RangeWeapon/FireBow")]

public class FireBow : NormalBow
{
    public override void ApplyDebuff(ref AttackDetails attackDetails)
    {
        base.ApplyDebuff(ref attackDetails);

        attackDetails.burn = true;
        Debug.Log("Fire arrow");
    }

    public override void SpellEnter(Player player, PlayerSpellState playerSpellState)
    {
        base.SpellEnter(player, playerSpellState);
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
