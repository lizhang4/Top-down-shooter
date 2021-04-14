using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "E1_Patrol", menuName = "Assets/EnemyStates/E1_Patrol")]

public class E1_PatrolSO : E_PatrolSO
{
    public override void StateExit(Enemy enemy, EnemyPatrolState enemyPatrolState)
    {
        base.StateExit(enemy, enemyPatrolState);
    }

    public override void StateEnter(Enemy enemy, EnemyPatrolState enemyPatrolState)
    {
        base.StateEnter(enemy, enemyPatrolState);

        enemyPatrolState.initialPosition = enemy.transform.position;

    }

    public override void StateUpdate(Enemy enemy, EnemyPatrolState enemyPatrolState)
    {
        base.StateUpdate(enemy, enemyPatrolState);

        if  (enemyPatrolState.playerInDetectedRange && enemyPatrolState.playerInRangeAttackRange) {
            // Change state to player detected state
            enemy.StateMachine.ChangeState(enemy.Attack1State);
        }
        else if (enemyPatrolState.playerInDetectedRange && enemyPatrolState.playerInMaxAgroRange) {
            enemy.StateMachine.ChangeState(enemy.MoveState);
        }

        // remains patrol

        if (enemyPatrolState.lastPathCheckUpdateTime + timeBtwUpdate <= Time.time) {
            enemyPatrolState.lastPathCheckUpdateTime = Time.time;

            enemyPatrolState.randomPos = (Vector2)enemyPatrolState.initialPosition + new Vector2(Random.Range(-patrolRadius, patrolRadius), Random.Range(-patrolRadius, patrolRadius)).normalized * patrolRadius;
            Collider2D hit = Physics2D.OverlapCircle(enemyPatrolState.randomPos, 0.5f);
            if(!hit) {
                Debug.Log("randomPosition: " + enemyPatrolState.randomPos);
                enemy.enemyAI.UpdatePath(enemyPatrolState.randomPos);
                enemy.enemyAI.reachedEndOfPath = false;

            }

        }
        if (enemy.enemyAI.reachedEndOfPath) {
            enemy.SetVelocityZero();
            
        }
        else {
            enemy.enemyAI.MoveToward(enemy.enemyData.moveSpeed);
        }
        
        //select random position in patrol radius;
        



    }

    
}
