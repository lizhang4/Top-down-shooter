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
        
    }

    public virtual void AnimationTrigger() {

    }

    public virtual void AnimationFinishTrigger() {
        isAnimationFinish = true;
    }




}
