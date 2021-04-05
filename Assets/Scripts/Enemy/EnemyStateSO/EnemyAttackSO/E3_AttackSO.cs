using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "E3_Attack", menuName = "Assets/EnemyStates/E3_Attack")]
public class E3_AttackSO : E_AttackSO
{

    private Vector2 attackDirection;
    private GameObject tempObj;
    private GameObject tempObj2;
    public override void StateEnter(Enemy enemy, EnemyAttackState enemyAttackState)
    {
        base.StateEnter(enemy, enemyAttackState);

        attackDetails.damageAmount = enemy.enemyData.baseDamage;
        attackDirection = enemy.facingDirection;

        if(lastAttackTime + attackCooldown <= Time.time) {

            tempObj = Instantiate(enemy.enemyData.projectile, enemy.attackPoint);
            tempObj.GetComponent<Laser>().lineRenderer.startWidth = 0.1f;
            tempObj.GetComponent<Laser>().lineRenderer.endWidth = 0.1f;
            tempObj.GetComponent<Laser>().fireDirection = attackDirection;

            

        }

    }

    public override void StateExit(Enemy enemy, EnemyAttackState enemyAttackState)
    {
        base.StateExit(enemy, enemyAttackState);
    }

    public override void StateUpdate(Enemy enemy, EnemyAttackState enemyAttackState)
    {
        base.StateUpdate(enemy, enemyAttackState);

        enemy.facingDirection = attackDirection;
        enemy.facingAngle = Vector2.SignedAngle(Vector2.up, attackDirection);
        enemy.transform.rotation = Quaternion.Euler(0,0,enemy.facingAngle);
        if(lastAttackTime + attackCooldown < Time.time) {
            if (attackAnticipationDuration + enemyAttackState.startTime < Time.time) {
                Destroy(tempObj);
                lastAttackTime = Time.time;
                RaycastHit2D playerHit = Physics2D.Raycast(enemy.attackPoint.position, attackDirection, enemy.enemyData.maxAgroRadius, enemy.enemyData.whatIsPlayer);
                Debug.Log(attackDirection);

                if(playerHit) {
                    playerHit.transform.SendMessage("Damage", attackDetails);
                }
                tempObj2 = Instantiate(enemy.enemyData.projectile, enemy.attackPoint);
                tempObj2.GetComponent<Laser>().lineRenderer.startWidth = 0.5f;
                tempObj2.GetComponent<Laser>().lineRenderer.endWidth = 0.5f;
                tempObj2.GetComponent<Laser>().fireDirection = attackDirection;
                tempObj2.GetComponent<Laser>().hitLayer += enemy.enemyData.whatIsPlayer;

                //Destroy(tempObj2);

            }
        }
        else if(lastAttackTime + 0.5f < Time.time) {
            Destroy(tempObj2);
            enemy.StateMachine.ChangeState(enemy.IdleState);
        }
        

    }
}
