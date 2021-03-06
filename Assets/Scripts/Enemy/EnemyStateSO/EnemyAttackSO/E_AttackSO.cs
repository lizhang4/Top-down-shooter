using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_AttackSO : ScriptableObject
{
    public float attackRate = 1f;
    public float attackCooldown = 3f;
    public float attackAnticipationDuration = 0.5f;
    protected AttackDetails attackDetails;
    
    public virtual void StateExit(Enemy enemy, EnemyAttackState enemyAttackState)
    {
        enemyAttackState.lastAttackTime = Time.time;
    }

    public virtual void StateEnter(Enemy enemy, EnemyAttackState enemyAttackState)
    {

    }

    public virtual void StateUpdate(Enemy enemy, EnemyAttackState enemyAttackState)
    {
        
    }


    public void InitializeLastAttackTime(Enemy enemy, EnemyAttackState enemyAttackState) {
        enemyAttackState.lastAttackTime = -10f;
    }
}
