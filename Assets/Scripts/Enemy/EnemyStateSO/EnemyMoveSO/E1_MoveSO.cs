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

        if  (enemyMoveState.playerInDetectedRange) {
            // Change state to player detected state
            enemy.StateMachine.ChangeState(enemy.Attack1State);
        }
        else if(!enemyMoveState.playerInDetectedRange && !enemyMoveState.playerInMaxAgroRange) {
            // Change state to idle state state
            enemy.StateMachine.ChangeState(enemy.PatrolState);
        }
        else if(!enemyMoveState.playerInDetectedRange && enemyMoveState.playerInMaxAgroRange) {
            // Remain at move state
            //Debug.Log("MoveState");
            // Debug.Log("Player Position: "+ enemy.GetPlayerPosition());
            enemy.SetVelocity(enemy.facingDirection, enemy.enemyData.moveSpeed);
            //enemy.MoveToPlayer();
        }
    }
}
