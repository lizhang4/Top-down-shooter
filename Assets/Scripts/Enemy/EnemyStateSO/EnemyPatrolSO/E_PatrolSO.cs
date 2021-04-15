using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_PatrolSO : ScriptableObject
{
    public float timeBtwUpdate = 2f;
    public float patrolRadius = 5f;
    public virtual void StateExit(Enemy enemy, EnemyPatrolState enemyPatrolState)
    {

    }

    public virtual void StateEnter(Enemy enemy, EnemyPatrolState enemyPatrolState)
    {

    }

    public virtual void StateUpdate(Enemy enemy, EnemyPatrolState enemyPatrolState)
    {
        
    }
}
