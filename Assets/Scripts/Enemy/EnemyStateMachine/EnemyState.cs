using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState 
{
    protected EnemyStateMachine stateMachine;
    protected Enemy enemy;
    protected EnemyData enemyData;


    public float startTime;
    private string animBoolName;
    protected bool isAnimationFinish;
    protected bool triggerEffect;

    public bool playerInDetectedRange {get; protected set;}
    public bool playerInMaxAgroRange {get; protected set;}
    public bool playerInCloseRange {get; protected set;}
    public bool playerInMidRange {get; protected set;}
    public bool PlayerInRetreatRange {get; protected set;}

    public EnemyState(Enemy enemy, EnemyStateMachine stateMachine, EnemyData enemyData, string animBoolName) {
        this.enemy = enemy;
        this.stateMachine = stateMachine;
        this.animBoolName = animBoolName;
        this.enemyData = enemyData;
    }

    public virtual void Enter() {
        startTime = Time.time;
        //enemy.anim.SetBool(animBoolName, true);
        //isAnimationFinish = false;
        //triggerEffect = false;
        Debug.Log(animBoolName);

        DoChecks();
    }

    public virtual void Exit() {
        //enemy.anim.SetBool(animBoolName, false);
    }

    public virtual void LogicUpdate () {

    }

    public virtual void PhysicUpdate() {
        DoChecks();
    }

    public virtual void DoChecks() {
        playerInDetectedRange = enemy.CheckPlayerInDetectedRange();
        playerInMaxAgroRange = enemy.CheckPlayerInMaxAgroRange();
        playerInCloseRange = enemy.CheckPlayerInCloseRange();
        playerInMidRange = enemy.CheckPlayerInMidRange();
        PlayerInRetreatRange = enemy.CheckPlayerInRetreatRange();

    }

    public virtual void AnimationTrigger() {

    }

    public virtual void AnimationFinishTrigger() {
        isAnimationFinish = true;
    }




}
