using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerState
{
    public PlayerIdleState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(attackInput ) {
            if(((1/player.weapon.attackRate) + player.AttackState.lastAttackTime < Time.time)){

                player.StateMachine.ChangeState(player.AttackState);
            }
        }
        if(abilityInput && player.ability.abilityCooldown + player.ability.lastAbilityTime <= Time.time){
            player.StateMachine.ChangeState(player.AbilityState);
        }
        if(spellInput && player.SpellState.lastSpellTime + player.weapon.spellCooldown <= Time.time) {
            Debug.Log(player.weapon.lastSpellTime);
            player.StateMachine.ChangeState(player.SpellState);
        }
        
        else if(movementInput != Vector2.zero) {
            player.StateMachine.ChangeState(player.MoveState);
        }
        else if(movementInput == Vector2.zero) {
            player.SetVelocityZero();
        }
    }

    
}
