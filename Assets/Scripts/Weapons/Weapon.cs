using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Assets/Weapon")]
public class Weapon : ScriptableObject
{
    [Header("Attack Details")]
    public int attackDamage = 1;
    public int spellDamage = 5;
    public float attackRate = 1f;
    public float attackCooldown;
    public float spellCooldown;
    //public float attackRadius = 1f;
    public LayerMask whatIsDamagable;
    

    public GameObject[] attackEffect = new GameObject[1];
    public GameObject[] spellEffect = new GameObject[1];

    public float lastAttackTime {get; protected set;}
    public float lastSpellTime {get; protected set;}
    protected AttackDetails attackDetails;


    protected GameObject tempObj;


    public virtual void AttackEnter(Player player, PlayerAttackState playerAttackState) {

    }

    public virtual void AttackLogicUpdate(Player player, PlayerAttackState playerAttackState) {
        
        // GameObject tempObj =  Instantiate(attackEffect[0], playerAttack.attackPoint.position, Quaternion.Euler(0,0,playerAttack.bulletAngle));
        // tempObj.GetComponent<Projectile>().facingDirection = playerAttack.facingDirection;
        // tempObj.GetComponent<Projectile>().attackDetails.damageAmount = attackDamage;

    }
    
    public virtual void AttackExit(Player player, PlayerAttackState playerAttackState) {
        lastAttackTime = Time.time;
    }

    public virtual void SpellEnter(Player player, PlayerSpellState playerSpellState) {
        
    }

    public virtual void SpellLogicUpdate(Player player, PlayerSpellState playerSpellState) {
        
    }

    public virtual void SpellExit(Player player, PlayerSpellState playerSpellState) {
        lastSpellTime = Time.time;
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

    public void InitialiseWeapon() {
        lastAttackTime = -10f;
        lastSpellTime = -10f;
    }

    public void SetLastSpellTime(float time) {
        lastSpellTime = time;
    }

    public void SetLastAttackTime(float time) {
        lastAttackTime = time;
    }
}
