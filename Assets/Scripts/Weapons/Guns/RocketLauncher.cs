using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RocketLauncher", menuName = "Assets/Guns/RocketLauncher")]
public class RocketLauncher : Gun
{
    public override void SpawnProjectile(Player player, PlayerAttackState playerAttackState)
    {
        base.SpawnProjectile(player, playerAttackState);
        tempObj.GetComponent<Projectile>().explosible = true;
    }
}
