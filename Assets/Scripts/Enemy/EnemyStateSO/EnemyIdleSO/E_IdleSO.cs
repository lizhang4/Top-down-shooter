using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_IdleSO : ScriptableObject
{
    public virtual void StateExit(Enemy enemy, EnemyIdleState enemyIdleState)
    {
        
    }

    public virtual void StateEnter(Enemy enemy, EnemyIdleState enemyIdleState)
    {
    }

    public virtual void StateUpdate(Enemy enemy, EnemyIdleState enemyIdleState)
    {
    }
}
