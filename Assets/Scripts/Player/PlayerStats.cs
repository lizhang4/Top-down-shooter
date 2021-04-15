using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : EntityStats
{
    [SerializeField]    
    private PlayerData playerData;
    
    //[SerializeField]
    //public int maxHealth = 5;
    private float lastDamageTime = 0;
    private float lastShieldRecoverTime = 0;



    protected override void Start() {
        //base.Start();
        currentHealth = playerData.maxHealth;
        currentShield = playerData.maxShield;
    }

    protected override void Die() {
        base.Die();
        //GM.Respawn();
    }

    public override void Damage(AttackDetails attackDetails)
    {

        if(!immuneDamage) {
            lastDamageTime = Time.time;
            if(currentShield > 0) {
                currentShield -= attackDetails.damageAmount;
                if(currentShield < 0) {
                    currentHealth += currentShield;
                    currentShield = 0;
                }
            }
            else {
                currentHealth -= attackDetails.damageAmount;
            }

            
            
            if(currentHealth <= 0) {
                currentHealth = 0;
                AudioManager.Instance.Play("PlayerDeath");

                Die();
            }
            
            
        }

        if (attackDetails.damageAmount > 0) {
            StartCoroutine(GetHit());
        }
        else {
            getHit = false;
        }

        if(attackDetails.freeze) {
            isFroze = true;
        }
        else if(attackDetails.shock) {
            isShocked = true;
        }
        else if(attackDetails.burn) {
            isBurned = true;
        }

        Debuff();

    }

    protected override void Update() {
        base.Update();

        ShieldRecovery();
    }

    private void ShieldRecovery() {
        if(currentShield != playerData.maxShield) {
            if(lastDamageTime + playerData.shieldRecoveryTimeAfterDamage <= Time.time) {
                if(lastShieldRecoverTime + playerData.shieldRecoveryTime <= Time.time) {
                    lastShieldRecoverTime = Time.time;
                    currentShield += 1;
                }
            }

        }
    }
}
