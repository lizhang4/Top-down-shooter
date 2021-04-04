using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dash", menuName = "Assets/Abilities/Dash")]
public class DashAbility : Ability
{
    public float dashSpeed = 30f;
    public float dashDuration = 0.5f;
    private Vector2 dashDir;


    public override void AbilityEnter(Player player, PlayerAbilityState playerAbilityState)
    {
        base.AbilityEnter(player, playerAbilityState);
        dashDir = playerAbilityState.movementInput;
        
    }

    public override void AbilityLogicUpdate(Player player, PlayerAbilityState playerAbilityState)
    {
        base.AbilityLogicUpdate(player, playerAbilityState);
        
        player.SetVelocity(dashDir.normalized, dashSpeed);
        if(playerAbilityState.startTime + dashDuration <= Time.time) {
            //player.SetVelocityZero();
            player.StateMachine.ChangeState(player.IdleState);
        }

        
    }

    public override void AbilityExit(Player player, PlayerAbilityState playerAbilityState)
    {
        base.AbilityExit(player, playerAbilityState);
    }
}
