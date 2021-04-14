using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class E_MoveSO : ScriptableObject
{
    public float timeBtwUpdate = 0.5f;
    public virtual void StateExit(Enemy enemy, EnemyMoveState enemyMoveState)
    {

    }

    public virtual void StateEnter(Enemy enemy, EnemyMoveState enemyMoveState)
    {

    }

    public virtual void StateUpdate(Enemy enemy, EnemyMoveState enemyMoveState)
    {
        
    }
}
