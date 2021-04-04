using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NormalBow", menuName = "Assets/RangeWeapon/NormalBow")]
public class NormalBow : RangeWeapon
{
    public float maxChargeDuration = 2f;
    public float maxDamageMultiplier = 3f;

    protected bool critAttack = false;
    private float chargeDuration;

    public override void AttackEnter(Player player, PlayerAttackState playerAttackState)
    {
        base.AttackEnter(player, playerAttackState);

    
    }

    public override void AttackExit(Player player, PlayerAttackState playerAttackState)
    {
        base.AttackExit(player, playerAttackState);
    }

    public override void AttackLogicUpdate(Player player, PlayerAttackState playerAttackState)
    {
        //base.AttackLogicUpdate(player, playerAttackState);

        if(playerAttackState.attackInput) {
            chargeDuration = Time.time - playerAttackState.startTime;
            Debug.Log("ChargeHolding");
        }
        else if(!playerAttackState.attackInput) {
            Debug.Log("ChargeRelease!" + "ChargeDuration: " + chargeDuration);
            int damageWorkspace;

            if(chargeDuration <= 1) {
                damageWorkspace = attackDamage;
            }
            else if(chargeDuration <= maxChargeDuration) {
                damageWorkspace = (int)(attackDamage * maxDamageMultiplier * (chargeDuration/maxChargeDuration));
            }
            else {
                damageWorkspace = (int)(attackDamage * maxDamageMultiplier);
                critAttack = true;
            }

            Debug.Log("Damage: "+ damageWorkspace);
            attackDetails.damageAmount = damageWorkspace;
            attackDetails.burn = false;
            attackDetails.freeze = false;
            attackDetails.shock = false;

            if(critAttack) {
                ApplyDebuff(ref attackDetails);
            }

            SpawnProjectile(player, playerAttackState, attackDetails);
            
            critAttack = false;
            player.StateMachine.ChangeState(player.IdleState);
        }
    }

    

    public override void WeaponGizmos(Player player)
    {
        base.WeaponGizmos(player);
    }
}
