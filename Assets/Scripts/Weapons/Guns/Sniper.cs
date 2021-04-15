using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Sniper", menuName = "Assets/Guns/Sniper")]
public class Sniper : Gun
{
    public override void SpawnProjectile(Player player, PlayerAttackState playerAttackState)
    {
        base.SpawnProjectile(player, playerAttackState);
        tempObj.GetComponent<Projectile>().penetratable = true;
    }

    public override void PlaySound()
    {
        base.PlaySound();
        AudioManager.Instance.Play("Shoot");
    }
}
