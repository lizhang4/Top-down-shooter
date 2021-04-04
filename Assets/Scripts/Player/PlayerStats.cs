using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : EntityStats
{
    // [SerializeField]    
    // private PlayerData playerData;
    [SerializeField]
    public int maxHealth = 5;

    protected override void Start() {
        base.Start();
        currentHealth = maxHealth;
    }

    protected override void Die() {
        base.Die();
        //GM.Respawn();
    }
}
