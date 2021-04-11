using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon
{
    public override void AttackLogicUpdate(Player player, PlayerAttackState playerAttackState)
    {
        base.AttackLogicUpdate(player, playerAttackState);

        if(playerAttackState.attackInput) {
            if(lastAttackTime + (1/attackRate) <= Time.time) {
                lastAttackTime = Time.time;
                SpawnProjectile(player, playerAttackState);
            }
        }
        else {
            player.StateMachine.ChangeState(player.IdleState);
        }
    }

    public virtual void SpawnProjectile(Player player, PlayerAttackState playerAttackState) {
        GameObject tempObj =  Instantiate(attackProjectile, player.attackPoint.position, Quaternion.Euler(0,0,player.facingAngle));
        tempObj.GetComponent<Projectile>().facingDirection = player.facingDirection;
        tempObj.GetComponent<Projectile>().attackDetails.damageAmount = attackDamage;
        tempObj.GetComponent<Projectile>().speed = attackProjectileSpeed;
        tempObj.GetComponent<Projectile>().playerAttack = true;
    }

}
