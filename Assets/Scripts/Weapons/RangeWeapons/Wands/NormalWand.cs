using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NormalWand", menuName = "Assets/RangeWeapon/NormalWand")]
public class NormalWand : RangeWeapon
{
    public override void AttackEnter(Player player, PlayerAttackState playerAttackState)
    {
        base.AttackEnter(player, playerAttackState);

        

    }
    public override void AttackLogicUpdate(Player player, PlayerAttackState playerAttackState)
    {
        //base.AttackLogicUpdate(player, playerAttackState);

        if(playerAttackState.attackInput) {
            if(lastAttackTime + (1/attackRate) <= Time.time){
                lastAttackTime = Time.time;
                SpawnProjectile(player, playerAttackState);
            }
        }
        else {
            player.StateMachine.ChangeState(player.IdleState);
        }
    }
}
