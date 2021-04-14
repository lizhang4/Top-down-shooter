using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "E1_Move", menuName = "Assets/EnemyStates/E1_Move")]
public class E1_MoveSO : E_MoveSO
{

    public override void StateExit(Enemy enemy, EnemyMoveState enemyMoveState)
    {
        base.StateExit(enemy, enemyMoveState);
    }

    public override void StateEnter(Enemy enemy, EnemyMoveState enemyMoveState)
    {
        base.StateEnter(enemy, enemyMoveState);

        enemy.SetVelocityZero();
    }

    public override void StateUpdate(Enemy enemy, EnemyMoveState enemyMoveState)
    {
        base.StateUpdate(enemy, enemyMoveState);

        if  (enemyMoveState.playerInDetectedRange && enemyMoveState.playerInRangeAttackRange) {
            // Change state to player detected state
            //enemy.enemyAI.stopMoving = true;
            enemy.SetVelocityZero();


            enemy.StateMachine.ChangeState(enemy.Attack1State);
        }
        else if(!enemyMoveState.playerInDetectedRange && !enemyMoveState.playerInMaxAgroRange) {
            // Change state to idle state state
            //enemy.enemyAI.stopMoving = true;
            enemy.SetVelocityZero();


            enemy.StateMachine.ChangeState(enemy.PatrolState);
        }
        else if(enemyMoveState.playerInMaxAgroRange) {
            enemy.enemyAI.stopMoving = false;

            if (enemyMoveState.lastPathCheckUpdateTime + timeBtwUpdate <= Time.time) {
                enemyMoveState.lastPathCheckUpdateTime = Time.time;

                enemy.enemyAI.UpdatePath(enemy.GetPlayerPosition());
                
            }
            enemy.enemyAI.MoveToward(enemy.enemyData.moveSpeed);
        }
        else {
            enemy.SetVelocityZero();
        }

    }
}
