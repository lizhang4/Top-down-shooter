using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyAbility", menuName = "Assets/EnemyAbility")]
public class EnemyAbility : ScriptableObject
{
    [Header("Attack Details")]
    public int attackModifier = 1;
    public float attackRate = 1f;
    public float attackRadius = 0.5f;
    
    

    public GameObject[] attackEffect = new GameObject[1];
    public GameObject projectile;

    public virtual void AbilityEnter(Enemy enemy) {

    }

    public virtual void AbilityLogicUpdate(Enemy enemy) {
        
        
    }

    public virtual void AnimationTrigger(){
        
    }
}
