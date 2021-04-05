using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlayerDetectedState : EnemyState
{   
    public EnemyPlayerDetectedState(Enemy enemy, EnemyStateMachine stateMachine, EnemyData enemyData, string animBoolName) : base(enemy, stateMachine, enemyData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();

        
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        // if out of detected range and out of max agro: change idle state
        // if out of detected range but in max agro: chase player
        // if in detected range but not close range: attack1 range
        // if in detected range and close range: attack2 melee
        if  (!playerInDetectedRange && !playerInMaxAgroRange) {
            // Change state to idle state
            //Debug.Log("IdleState");
            enemy.StateMachine.ChangeState(enemy.IdleState);
        }
        else if(!playerInDetectedRange && playerInMaxAgroRange) {
            // Change to move state
            //Debug.Log("MoveState");
            enemy.StateMachine.ChangeState(enemy.MoveState);
        }
        else if(playerInDetectedRange && !playerInCloseRange) {
            // change to attack1 state
            //Debug.Log("Attack1, range attack");
            enemy.StateMachine.ChangeState(enemy.Attack1State);
        }
        else if(playerInDetectedRange && playerInCloseRange) {
            // change to attack2 state
            //Debug.Log("Attack2, melee attack");
            Debug.Log("Retreat");
            enemy.SetVelocity(enemy.facingDirection, -enemyData.moveSpeed);

            //enemy.StateMachine.ChangeState(enemy.MoveState);

            //enemy.StateMachine.ChangeState(enemy.Attack2State);
        }
    }
}
