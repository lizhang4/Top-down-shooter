using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "E1_Attack", menuName = "Assets/EnemyStates/E1_Attack")]
public class E1_AttackSO : E_AttackSO
{

    
    public override void StateExit(Enemy enemy, EnemyAttackState enemyAttackState)
    {
        base.StateExit(enemy, enemyAttackState);
    }

    public override void StateEnter(Enemy enemy, EnemyAttackState enemyAttackState)
    {
        base.StateEnter(enemy, enemyAttackState);
    }

    public override void StateUpdate(Enemy enemy, EnemyAttackState enemyAttackState)
    {
        base.StateUpdate(enemy, enemyAttackState);

        if(enemyAttackState.playerInDetectedRange) {
            // change to attack1 state
            //Debug.Log("Attack1, attacking");
            //Debug.Log("Player Position: "+ enemy.GetPlayerPosition());
            //enemy.facingDirection = enemy.GetPlayerPosition() - (Vector2)enemy.transform.position;
            if (enemyAttackState.lastAttackTime + 1/attackRate < Time.time) {
                enemyAttackState.lastAttackTime = Time.time;
                enemy.enemyAttack[0].AbilityLogicUpdate(enemy);
            }

            // Movement
            // if(!enemyAttackState.playerInMidRange) {
            //     Debug.Log("Follow");
            //     enemy.SetVelocity(enemy.facingDirection, enemy.enemyData.moveSpeed/2);
            // }
            // else if(enemyAttackState.PlayerInRetreatRange) {
            //     Debug.Log("Retreat");
            //     enemy.SetVelocity(enemy.facingDirection, -enemy.enemyData.moveSpeed/2);
            // }

        }

        if  (!enemyAttackState.playerInDetectedRange && !enemyAttackState.playerInMaxAgroRange) {
            // Change state to idle state
            enemy.StateMachine.ChangeState(enemy.PatrolState);
        }
        if(!enemyAttackState.playerInDetectedRange && enemyAttackState.playerInMaxAgroRange) {
            // Change to move state
            enemy.StateMachine.ChangeState(enemy.MoveState);
        }
        
        // Movement
        


    }
}
