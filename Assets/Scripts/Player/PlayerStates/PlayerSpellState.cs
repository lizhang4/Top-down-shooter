using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpellState : PlayerState
{
    public float lastSpellTime;
    public PlayerSpellState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();

        player.weapon.SpellAnimationFinishTrigger(player, this);
    }

    public override void AnimationTrigger()
    {
        base.AnimationTrigger();

        player.weapon.SpellAnimationTrigger(player, this);
    }


    public override void Enter()
    {
        base.Enter();
        
        player.weapon.SpellEnter(player, this);
        if(movementInput != Vector2.zero){
            player.SetVelocity(movementInput, playerData.moveSpeed);
        }

        
    }

    public override void Exit()
    {
        base.Exit();

        player.weapon.SpellExit(player, this);
        
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        player.weapon.SpellLogicUpdate(player, this);
        if(movementInput != Vector2.zero){
            player.SetVelocity(movementInput, playerData.moveSpeed);
        }
        else {
            player.SetVelocityZero();
        }
        if(attackInput && (1/player.weapon.attackRate + player.AttackState.lastAttackTime < Time.time)) {
            player.StateMachine.ChangeState(player.AttackState);
        }

        if(abilityInput && player.ability.abilityCooldown + player.ability.lastAbilityTime <= Time.time){

            player.StateMachine.ChangeState(player.AbilityState);
        }
    }

}
