using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyState
{
    public EnemyIdleState(Enemy enemy, EnemyStateMachine stateMachine, EnemyData enemyData, string animBoolName) : base(enemy, stateMachine, enemyData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        enemy.idleSO.StateEnter(enemy, this);

    }


    public override void Exit()
    {
        base.Exit();
        enemy.idleSO.StateExit(enemy, this);

    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        enemy.idleSO.StateUpdate(enemy, this);
    }
}
