using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NormalSword", menuName = "Assets/MeleeWeapon/Swords")]
public class NormalSword : MeleeWeapon
{
    public override void AttackLogicUpdate(Player player, PlayerAttackState playerAttackState)
    {
        base.AttackLogicUpdate(player, playerAttackState);

    }

}
