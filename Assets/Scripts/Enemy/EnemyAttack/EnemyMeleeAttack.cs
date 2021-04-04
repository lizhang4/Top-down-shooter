using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyMeleeAttack", menuName = "Assets/EnemyMeleeAttack")]

public class EnemyMeleeAttack : EnemyAbility
{
    public float maxDashDistance = 3f;
    public float dashSpeed = 15f;
    private Vector2 enemyStartPos;
    private Vector2 playerStartPos;
    private AttackDetails attackDetails;
    private Enemy enemy;


    public override void AbilityEnter(Enemy enemy)
    {
        base.AbilityEnter(enemy);

        // enemyStartPos = enemy.transform.position;
        // playerStartPos = enemy.GetPlayerPosition();

        // if(enemy.GetDistanceBetweenPlayer() < maxDashDistance) {
        //     enemy.SetVelocity(enemy.facingDirection, dashSpeed);
        // }
        // else {

        // }
        this.enemy = enemy;

        GameObject tempObj = Instantiate(attackEffect[0], enemy.transform.position, Quaternion.identity, enemy.transform);
        Debug.Log("Spawn Obj");
        
    }
    public override void AbilityLogicUpdate(Enemy enemy)
    {
        base.AbilityLogicUpdate(enemy);

        
        // Debug.Log("MeleeDamage");
        // Collider2D player = Physics2D.OverlapCircle(enemy.transform.position, attackRadius, enemy.enemyData.whatIsPlayer);

        // attackDetails.damageAmount = attackModifier;
        // player.SendMessage("Damage", attackDetails);
    }

    public override void AnimationTrigger() {
        base.AnimationTrigger();
        Collider2D player = Physics2D.OverlapCircle(enemy.transform.position, attackRadius, enemy.enemyData.whatIsPlayer);
        if (player != null) {
            attackDetails.damageAmount = attackModifier;
            player.SendMessage("Damage", attackDetails);
        }
    }

}
