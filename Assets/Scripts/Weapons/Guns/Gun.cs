using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon
{
    public float maxTravelDistance = 20f;
    public override void AttackLogicUpdate(Player player, PlayerAttackState playerAttackState)
    {
        base.AttackLogicUpdate(player, playerAttackState);

        if(playerAttackState.attackInput) {
            if(playerAttackState.lastAttackTime + (1/attackRate) <= Time.time) {
                PlaySound();
                playerAttackState.lastAttackTime = Time.time;
                SpawnProjectile(player, playerAttackState);
            }
        }
        else {
            player.StateMachine.ChangeState(player.IdleState);
        }
    }

    public virtual void PlaySound() {

    }

    public virtual void SpawnProjectile(Player player, PlayerAttackState playerAttackState) {
        tempObj =  Instantiate(attackProjectile, player.attackPoint.position, Quaternion.Euler(0,0,player.facingAngle));
        tempObj.GetComponent<Projectile>().facingDirection = player.facingDirection;
        tempObj.GetComponent<Projectile>().attackDetails.damageAmount = attackDamage;
        tempObj.GetComponent<Projectile>().speed = attackProjectileSpeed;
        tempObj.GetComponent<Projectile>().maxTravelDistance = maxTravelDistance;
        tempObj.GetComponent<Projectile>().playerAttack = true;
    }

}
