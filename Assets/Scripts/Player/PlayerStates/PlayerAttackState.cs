using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerState
{
    public float lastAttackTime {get; private set;}
    public PlayerAttackState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();

        player.weapon.AttackAnimationFinishTrigger(player, this);
        lastAttackTime = Time.time;
        player.StateMachine.ChangeState(player.IdleState);

    }

    public override void AnimationTrigger()
    {
        base.AnimationTrigger();

        player.weapon.AttackAnimationTrigger(player, this);
    }

    public override void Enter()
    {
        base.Enter();

        player.weapon.AttackEnter(player, this);
        if(movementInput != Vector2.zero){
            player.SetVelocity(movementInput, playerData.moveSpeed);
        }
    }

    public override void Exit()
    {
        base.Exit();

        player.weapon.AttackExit(player, this);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        player.weapon.AttackLogicUpdate(player, this);

        if(movementInput != Vector2.zero){
            player.SetVelocity(movementInput, playerData.moveSpeed);
        }
        else {
            player.SetVelocityZero();
        }

        if(abilityInput && player.ability.abilityCooldown + player.ability.lastAbilityTime <= Time.time){

            player.StateMachine.ChangeState(player.AbilityState);
        }

        if(spellInput && player.weapon.lastSpellTime + player.weapon.spellCooldown <= Time.time) {
            player.StateMachine.ChangeState(player.SpellState);
        }
        
    }
    
}
