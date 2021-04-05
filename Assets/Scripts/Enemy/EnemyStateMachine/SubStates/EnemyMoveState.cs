using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveState : EnemyState
{
    private Vector2 moveDirection;
    public EnemyMoveState(Enemy enemy, EnemyStateMachine stateMachine, EnemyData enemyData, string animBoolName) : base(enemy, stateMachine, enemyData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();

        enemy.moveSO.StateEnter(enemy, this);
    }

    public override void Exit()
    {
        base.Exit();
        //enemy.SetVelocityZero();

        enemy.moveSO.StateExit(enemy, this);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        

        // if  (playerInDetectedRange) {
        //     // Change state to player detected state
        //     enemy.StateMachine.ChangeState(enemy.PlayerDetectedState);
        // }
        // else if(!playerInDetectedRange && !playerInMaxAgroRange) {
        //     // Change state to idle state state
        //     enemy.StateMachine.ChangeState(enemy.IdleState);
        // }
        // else if(!playerInDetectedRange && playerInMaxAgroRange) {
        //     // Remain at move state
        //     //Debug.Log("MoveState");
        //     // Debug.Log("Player Position: "+ enemy.GetPlayerPosition());
        //     enemy.SetVelocity(enemy.facingDirection, enemyData.moveSpeed);
        //     //enemy.MoveToPlayer();
        // }
        // else if(playerInDetectedRange && playerInCloseRange) {
        //     enemy.SetVelocity(enemy.facingDirection, -enemyData.moveSpeed);
        // }

        enemy.moveSO.StateUpdate(enemy, this);
    }
}
