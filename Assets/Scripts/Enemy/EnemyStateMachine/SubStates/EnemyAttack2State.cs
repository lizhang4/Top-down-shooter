using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack2State : EnemyAttackState
{
    private float lastAttackTime;
    public EnemyAttack2State(Enemy enemy, EnemyStateMachine stateMachine, EnemyData enemyData, string animBoolName) : base(enemy, stateMachine, enemyData, animBoolName)
    {
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
    }

    public override void AnimationTrigger()
    {
        base.AnimationTrigger();

        enemy.enemyAttack[1].AnimationTrigger();
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();

        enemy.enemyAttack[1].AbilityEnter(enemy);

    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        // if(playerInDetectedRange && playerInCloseRange) {
        //     // change to attack1 state
        //     Debug.Log("Attack2, attacking");
        //     //Debug.Log("Player Position: "+ enemy.GetPlayerPosition());
        //     //enemy.facingDirection = enemy.GetPlayerPosition() - (Vector2)enemy.transform.position;
        //     if (lastAttackTime + 1/enemy.enemyAttack[1].attackRate < Time.time) {
        //         lastAttackTime = Time.time;
        //         enemy.enemyAttack[1].AbilityLogicUpdate(enemy);
        //     }
        // }
        if  (!playerInDetectedRange && !playerInMaxAgroRange) {
            // Change state to idle state
            Debug.Log("IdleState");
            enemy.StateMachine.ChangeState(enemy.IdleState);
        }
        else if(!playerInDetectedRange && playerInMaxAgroRange) {
            // Change to move state
            Debug.Log("MoveState");
            enemy.StateMachine.ChangeState(enemy.MoveState);
        }
        
        else if(playerInDetectedRange && !playerInCloseRange) {
            // change to attack2 state
            Debug.Log("Attack1, range attack");
            enemy.StateMachine.ChangeState(enemy.Attack1State);
        }
    }


    
}
