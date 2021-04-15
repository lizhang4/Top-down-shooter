using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Assets/Weapon")]
public class Weapon : ScriptableObject
{
    [Header("Attack Details")]
    public int attackDamage = 1;
    public int attackManaCost = 0;
    public float attackRate = 1f;
    public float attackCooldown;
    public float firingSpread;
    public float bulletSpread;
    public float attackProjectileSpeed = 20f;
    public bool allowButtonHold = true;
    public GameObject attackProjectile;


    [Header("Spell Details")]
    public int spellDamage = 5;
    public float spellCooldown;
    

    public LayerMask whatIsDamagable;
    public GameObject[] attackEffect = new GameObject[1];
    public GameObject[] spellEffect = new GameObject[1];



    public float lastAttackTime {get; protected set;}
    public float lastSpellTime {get; protected set;}

    // Temperory variables
    protected AttackDetails attackDetails;
    protected GameObject tempObj;
        
    public virtual void AttackEnter(Player player, PlayerAttackState playerAttackState) {

    }

    public virtual void AttackLogicUpdate(Player player, PlayerAttackState playerAttackState) {

    }
    
    public virtual void AttackExit(Player player, PlayerAttackState playerAttackState) {
        playerAttackState.lastAttackTime = Time.time;
    }
    



    public virtual void SpellEnter(Player player, PlayerSpellState playerSpellState) {
        
    }

    public virtual void SpellLogicUpdate(Player player, PlayerSpellState playerSpellState) {
        
    }

    public virtual void SpellExit(Player player, PlayerSpellState playerSpellState) {
        playerSpellState.lastSpellTime= Time.time;
    }



    public virtual void AttackAnimationTrigger(Player player, PlayerAttackState playerAttackState) {

    }

    public virtual void AttackAnimationFinishTrigger(Player player, PlayerAttackState playerAttackState) {
        
    }
    public virtual void SpellAnimationTrigger(Player player, PlayerSpellState playerSpellState) {
        
    }
    public virtual void SpellAnimationFinishTrigger(Player player, PlayerSpellState playerSpellState) {
        
    }

    public virtual void WeaponGizmos(Player player) {

    }

    public void InitialiseWeapon(PlayerAttackState playerAttackState) {
        playerAttackState.lastAttackTime = -10f;
        playerAttackState.lastAttackTime = -10f;
    }

    public void SetLastSpellTime(float time) {
        lastSpellTime = time;
    }

    public void SetLastAttackTime(float time) {
        lastAttackTime = time;
    }
}
