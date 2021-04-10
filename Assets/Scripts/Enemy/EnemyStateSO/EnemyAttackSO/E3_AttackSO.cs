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


        Debug.Log(enemy.gameObject.name);
        attackDetails.damageAmount = enemy.enemyData.baseDamage;
        enemyAttackState.attackDirection = enemy.facingDirection;

        if(enemyAttackState.lastAttackTime + attackCooldown <= Time.time) {

            enemyAttackState.tempObj = Instantiate(enemy.enemyData.projectile, enemy.attackPoint);
            enemyAttackState.tempObj.GetComponent<Laser>().lineRenderer.startWidth = 0.1f;
            enemyAttackState.tempObj.GetComponent<Laser>().lineRenderer.endWidth = 0.1f;
            enemyAttackState.tempObj.GetComponent<Laser>().fireDirection = attackDirection;

            

        }

    }

    public override void StateExit(Enemy enemy, EnemyAttackState enemyAttackState)
    {
        base.StateExit(enemy, enemyAttackState);

        //tempObj2.GetComponent<Laser>().hitLayer -= enemy.enemyData.whatIsPlayer;

    }

    public override void StateUpdate(Enemy enemy, EnemyAttackState enemyAttackState)
    {
        base.StateUpdate(enemy, enemyAttackState);

        enemy.facingDirection = enemyAttackState.attackDirection;
        enemy.facingAngle = Vector2.SignedAngle(Vector2.up, enemyAttackState.attackDirection);
        enemy.transform.rotation = Quaternion.Euler(0,0,enemy.facingAngle);
        if(enemyAttackState.lastAttackTime + attackCooldown < Time.time) {
            if (attackAnticipationDuration + enemyAttackState.startTime < Time.time) {
                Destroy(enemyAttackState.tempObj);
                enemyAttackState.lastAttackTime = Time.time;
                RaycastHit2D playerHit = Physics2D.Raycast(enemy.attackPoint.position, enemyAttackState.attackDirection, enemy.enemyData.maxAgroRadius, enemy.enemyData.whatIsPlayer);
                Debug.Log(enemyAttackState.attackDirection);

                if(playerHit) {
                    playerHit.transform.SendMessage("Damage", attackDetails);
                }
                enemyAttackState.tempObj = Instantiate(enemy.enemyData.projectile, enemy.attackPoint);
                enemyAttackState.tempObj.GetComponent<Laser>().lineRenderer.startWidth = 0.5f;
                enemyAttackState.tempObj.GetComponent<Laser>().lineRenderer.endWidth = 0.5f;
                enemyAttackState.tempObj.GetComponent<Laser>().fireDirection = enemyAttackState.attackDirection;
                enemyAttackState.tempObj.GetComponent<Laser>().hitLayer += enemy.enemyData.whatIsPlayer;

                //Destroy(tempObj2);

            }
        }
        else if(enemyAttackState.lastAttackTime + 0.5f < Time.time) {
            Destroy(enemyAttackState.tempObj);
            enemy.StateMachine.ChangeState(enemy.IdleState);
        }
        

    }
}
