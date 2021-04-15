using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "E2_Patrol", menuName = "Assets/EnemyStates/E2_Patrol")]

public class E2_PatrolSO : E_PatrolSO
{
    public override void StateEnter(Enemy enemy, EnemyPatrolState enemyPatrolState)
    {
        base.StateEnter(enemy, enemyPatrolState);
        enemy.SetVelocityZero();

    }

    public override void StateExit(Enemy enemy, EnemyPatrolState enemyPatrolState)
    {
        base.StateExit(enemy, enemyPatrolState);
        enemy.SetVelocityZero();

    }

    public override void StateUpdate(Enemy enemy, EnemyPatrolState enemyPatrolState)
    {
        base.StateUpdate(enemy, enemyPatrolState);

        if  (enemyPatrolState.playerInCloseRange) {
            // Change state to player detected state
            if(enemy.attackSO.attackCooldown + enemy.Attack1State.lastAttackTime <= Time.time) {
                enemy.StateMachine.ChangeState(enemy.Attack1State);
            }
        }
        if (enemyPatrolState.playerInDetectedRange && !enemyPatrolState.playerInCloseRange){
            enemy.StateMachine.ChangeState(enemy.MoveState);
        }
    }
}
