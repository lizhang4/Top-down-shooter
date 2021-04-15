using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerState
{
    public PlayerMoveState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }


    public override void Enter()
    {
        base.Enter();

        if(movementInput != Vector2.zero){
            player.SetVelocity(movementInput, playerData.moveSpeed);
        }
        else if(movementInput == Vector2.zero) {
            player.StateMachine.ChangeState(player.IdleState);
        }
    }


    public override void Exit()
    {
        base.Exit();

        player.SetVelocityZero();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(attackInput && (1/player.weapon.attackRate + player.AttackState.lastAttackTime < Time.time)) {
            player.StateMachine.ChangeState(player.AttackState);
        }
        if(abilityInput && player.ability.abilityCooldown + player.ability.lastAbilityTime <= Time.time){

            player.StateMachine.ChangeState(player.AbilityState);
        }
        else if(spellInput && player.SpellState.lastSpellTime + player.weapon.spellCooldown <= Time.time) {
            player.StateMachine.ChangeState(player.SpellState);
        }
        if(movementInput != Vector2.zero){
            player.SetVelocity(movementInput, playerData.moveSpeed);
        }
        else if(movementInput == Vector2.zero) {
            player.StateMachine.ChangeState(player.IdleState);
        }
    }

    
}
