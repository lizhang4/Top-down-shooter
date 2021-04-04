using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyRangeAttack", menuName = "Assets/EnemyRangeAttack")]

public class EnemyRangeAttack : EnemyAbility
{
    public override void AbilityLogicUpdate(Enemy enemy)
    {
        base.AbilityLogicUpdate(enemy);

        GameObject tempObj = Instantiate(projectile, enemy.attackPoint.position, Quaternion.Euler(0,0,enemy.facingAngle));
        tempObj.GetComponent<Projectile>().facingDirection = enemy.facingDirection;
        tempObj.GetComponent<Projectile>().attackDetails.damageAmount = enemy.enemyData.baseDamage*attackModifier;
        tempObj.GetComponent<Projectile>().playerAttack = false;
    }

    
}
