using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "E2_Move", menuName = "Assets/EnemyStates/E2_Move")]
public class E2_MoveSO : E_MoveSO
{
    public override void StateEnter(Enemy enemy, EnemyMoveState enemyMoveState)
    {
        base.StateEnter(enemy, enemyMoveState);
        enemy.SetVelocityZero();

    }

    public override void StateExit(Enemy enemy, EnemyMoveState enemyMoveState)
    {
        base.StateExit(enemy, enemyMoveState);
        enemy.SetVelocityZero();

    }

    public override void StateUpdate(Enemy enemy, EnemyMoveState enemyMoveState)
    {
        base.StateUpdate(enemy, enemyMoveState);
        
        if(enemyMoveState.playerInMaxAgroRange) {
            enemy.SetVelocity(enemy.facingDirection, enemy.enemyData.moveSpeed);
        }

        if  (enemyMoveState.playerInCloseRange) {
            // Change state to player detected state
            enemy.SetVelocityZero();
            if(enemy.attackSO.attackCooldown + enemy.attackSO.lastAttackTime <= Time.time) {
                enemy.StateMachine.ChangeState(enemy.Attack1State);
            }
        }
        if(!enemyMoveState.playerInMaxAgroRange) {
            // Change state to idle state state
            enemy.StateMachine.ChangeState(enemy.PatrolState);
        }
        
    }

}
