using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyState
{
    protected bool playerInDetectedRange;
    protected bool playerInMaxAgroRange;
    protected bool playerInCloseRange;

    protected bool hasAbilityDone;

    protected float minExitTime = 2f;
    public EnemyAttackState(Enemy enemy, EnemyStateMachine stateMachine, EnemyData enemyData, string animBoolName) : base(enemy, stateMachine, enemyData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
        playerInDetectedRange = enemy.CheckPlayerInDetectedRange();
        playerInMaxAgroRange = enemy.CheckPlayerInMaxAgroRange();
        playerInCloseRange = enemy.CheckPlayerInCloseRange();
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

        if(hasAbilityDone && minExitTime + startTime < Time.time) {
            stateMachine.ChangeState(enemy.PlayerDetectedState);
        }
    }

    public override void AnimationTrigger()
    {
        base.AnimationTrigger();
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();

        hasAbilityDone = true;
    }
}
