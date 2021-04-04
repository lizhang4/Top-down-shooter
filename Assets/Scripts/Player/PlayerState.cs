using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState 
{
    protected PlayerStateMachine stateMachine;
    protected Player player;
    protected PlayerData playerData;


    public float startTime;
    private string animBoolName;
    protected bool isAnimationFinish;
    protected bool triggerEffect;

    // Inputs
    public Vector2 movementInput;
    public bool attackInput {get; private set;}
    public bool attackDownInput {get; private set;}
    public bool attackUpInput {get; private set;}
    public bool spellInput {get; private set;}
    protected bool spellDownInput;
    public bool spellUpInput {get; private set;}
    public bool abilityInput {get; private set;}

    public PlayerState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) {
        this.player = player;
        this.stateMachine = stateMachine;
        this.animBoolName = animBoolName;
        this.playerData = playerData;
    }

    public virtual void Enter() {
        startTime = Time.time;
        //player.anim.SetBool(animBoolName, true);
        //isAnimationFinish = false;
        //triggerEffect = false;
        Debug.Log(animBoolName);

        CheckInput();
        DoChecks();
    }
    

    public virtual void Exit() {
        //player.anim.SetBool(animBoolName, false);
    }

    public virtual void LogicUpdate () {
        CheckInput();
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

    public virtual void CheckInput() {
        movementInput.x = Input.GetAxisRaw("Horizontal");
        movementInput.y = Input.GetAxisRaw("Vertical");
        attackInput = Input.GetMouseButton(0);
        attackDownInput = Input.GetMouseButtonDown(0);
        attackUpInput = Input.GetMouseButtonUp(0);
        spellInput = Input.GetMouseButton(1);
        spellDownInput = Input.GetMouseButtonDown(1);
        spellUpInput = Input.GetMouseButtonUp(1);
        abilityInput = Input.GetKey(KeyCode.Space);

    }
}
