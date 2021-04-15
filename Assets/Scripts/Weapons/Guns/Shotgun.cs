using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Shotgun", menuName = "Assets/Guns/Shotgun")]
public class Shotgun : Gun
{
    public int bulletAmount;
    public override void SpawnProjectile(Player player, PlayerAttackState playerAttackState)
    {
        //base.SpawnProjectile(player, playerAttackState);
        float facingRotation = Mathf.Atan2(player.facingDirection.y, player.facingDirection.x) * Mathf.Rad2Deg;

        float startRotation = facingRotation + bulletSpread/2f;

        float angleIncrease = bulletSpread / ((float)bulletAmount - 1f);

        for (int i = 0; i < bulletAmount; i++) {
            float tempRot = startRotation - angleIncrease * i;

            tempObj = Instantiate(attackProjectile, player.attackPoint.position, Quaternion.Euler(0f,0f, tempRot-90f));

            tempObj.GetComponent<Projectile>().facingDirection = new Vector2(Mathf.Cos(tempRot * Mathf.Deg2Rad), Mathf.Sin(tempRot * Mathf.Deg2Rad));
            tempObj.GetComponent<Projectile>().attackDetails.damageAmount = attackDamage;
            tempObj.GetComponent<Projectile>().speed = attackProjectileSpeed;
            tempObj.GetComponent<Projectile>().playerAttack = true;
        }
        
    }

    public override void PlaySound()
    {
        base.PlaySound();
        AudioManager.Instance.Play("Shoot");
    }
}
