using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "E3_Idle", menuName = "Assets/EnemyStates/E3_Idle")]
public class E3_IdleSO : E_IdleSO
{
    public override void StateEnter(Enemy enemy, EnemyIdleState enemyIdleState)
    {
        base.StateEnter(enemy, enemyIdleState);
    }

    public override void StateExit(Enemy enemy, EnemyIdleState enemyIdleState)
    {
        base.StateExit(enemy, enemyIdleState);
    }

    public override void StateUpdate(Enemy enemy, EnemyIdleState enemyIdleState)
    {
        base.StateUpdate(enemy, enemyIdleState);

        if  (enemyIdleState.playerInDetectedRange) {
            // Change state to player detected state
            if(enemy.attackSO.lastAttackTime + enemy.attackSO.attackCooldown <= Time.time) {

                enemy.StateMachine.ChangeState(enemy.Attack1State);
            }
        }
    }
}
