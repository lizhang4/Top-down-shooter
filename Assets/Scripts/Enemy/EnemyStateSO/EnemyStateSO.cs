using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyStateSO : ScriptableObject
{
    public virtual void StateStart(Enemy enemy, EnemyState enemyState) {

    }

    public virtual void StateUpdate(Enemy enemy, EnemyState enemyState) {

    }

    public virtual void StateExit(Enemy enemy, EnemyState enemyState) {

    }
}
