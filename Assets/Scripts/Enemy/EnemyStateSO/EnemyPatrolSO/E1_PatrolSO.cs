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

    }

    public override void StateUpdate(Enemy enemy, EnemyPatrolState enemyPatrolState)
    {
        base.StateUpdate(enemy, enemyPatrolState);

        if  (enemyPatrolState.playerInDetectedRange) {
            // Change state to player detected state
            enemy.StateMachine.ChangeState(enemy.Attack1State);
        }

    }
}
