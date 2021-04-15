using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "E1_Idle", menuName = "Assets/EnemyStates/E1_Idle")]
public class E1_IdleSO : E_IdleSO
{
    public override void StateExit(Enemy enemy, EnemyIdleState enemyIdleState)
    {
        base.StateExit(enemy, enemyIdleState);

    }

    public override void StateEnter(Enemy enemy, EnemyIdleState enemyIdleState)
    {
        base.StateEnter(enemy, enemyIdleState);

        enemy.StateMachine.ChangeState(enemy.PatrolState);
    }

    public override void StateUpdate(Enemy enemy, EnemyIdleState enemyIdleState)
    {
        base.StateUpdate(enemy, enemyIdleState);
    }
}
