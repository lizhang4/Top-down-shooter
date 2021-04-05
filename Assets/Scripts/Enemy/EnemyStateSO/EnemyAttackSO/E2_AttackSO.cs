using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "E2_Attack", menuName = "Assets/EnemyStates/E2_Attack")]
public class E2_AttackSO : E_AttackSO
{
    public override void StateEnter(Enemy enemy, EnemyAttackState enemyAttackState)
    {
        base.StateEnter(enemy, enemyAttackState);
        enemy.SetVelocityZero();

    }

    public override void StateExit(Enemy enemy, EnemyAttackState enemyAttackState)
    {
        base.StateExit(enemy, enemyAttackState);
        enemy.SetVelocityZero();

    }

    public override void StateUpdate(Enemy enemy, EnemyAttackState enemyAttackState)
    {
        base.StateUpdate(enemy, enemyAttackState);

        if(enemyAttackState.playerInCloseRange) {
            enemy.SetVelocityZero();
            if(lastAttackTime + attackCooldown <= Time.time){
                lastAttackTime = Time.time;
                Debug.Log("Attack");

            }
        }
        else {
            
            enemy.StateMachine.ChangeState(enemy.MoveState);
            
        }

        if(!enemyAttackState.playerInMaxAgroRange) {
            enemy.StateMachine.ChangeState(enemy.PatrolState);
        }
    }
}
