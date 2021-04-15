using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolState : EnemyState
{
    public float lastPathCheckUpdateTime = -10f;
    public Vector3 initialPosition;
    public Vector2 randomPos;
    public EnemyPatrolState(Enemy enemy, EnemyStateMachine stateMachine, EnemyData enemyData, string animBoolName) : base(enemy, stateMachine, enemyData, animBoolName)
    {
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
    }

    public override void AnimationTrigger()
    {
        base.AnimationTrigger();
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();

        enemy.patrolSO.StateEnter(enemy, this);
    }

    public override void Exit()
    {
        base.Exit();

        enemy.patrolSO.StateExit(enemy, this);

    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        enemy.patrolSO.StateUpdate(enemy, this);

    }
}
