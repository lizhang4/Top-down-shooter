using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : EntityStats
{
    [SerializeField]
    //private EnemyData enemyData;
    private int maxHealth = 5;
    

    protected override void Start()
    {
        base.Start();
        currentHealth = maxHealth;
    }

    protected override void Die()
    {
        PlayerStatsUI.Instance.AddScore();
        base.Die();
        

    }
}
