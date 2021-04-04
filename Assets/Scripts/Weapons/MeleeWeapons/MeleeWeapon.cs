using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MeleeWeapon", menuName = "Assets/MeleeWeapon")]
public class MeleeWeapon : Weapon
{
    public float attackRadius;
    public float spellRadius;

    //TEMP Variables
    

    public override void AttackEnter(Player player, PlayerAttackState playerAttackState)
    {
        base.AttackEnter(player, playerAttackState);
        attackDetails.damageAmount = attackDamage;
        tempObj = Instantiate(attackEffect[0], player.attackPoint);
        if (attackEffect.Length > 1){
            Instantiate(attackEffect[1], player.attackPoint);
        }
        if (tempObj.GetComponent<Animator>() != null) {
            Animator anim = tempObj.GetComponent<Animator>();
            anim.SetBool("Attack", true);
        }
    }

    public override void AttackLogicUpdate(Player player, PlayerAttackState playerAttackState)
    {
        base.AttackLogicUpdate(player, playerAttackState);
        

        // Collider2D[] enemiesHit = Physics2D.OverlapCircleAll(playerAttack.attackPoint.position, attackRadius, whatIsDamagable);

        // foreach (Collider2D enemy in enemiesHit) {
        //     enemy.transform.SendMessage("Damage", attackDetails);
        // }    
    }

    // public override void SpellLogicUpdate(PlayerAttack playerAttack, PlayerMovement playerMovement)
    // {
    //     base.SpellLogicUpdate(playerAttack, playerMovement);
    //     attackDetails.damageAmount = attackDamage;
    //     tempObj = Instantiate(attackEffect[0], playerAttack.attackPoint);
    //     Animator anim = tempObj.GetComponent<Animator>();
    //     anim.SetBool("Spell", true);

    // }

    public override void AttackAnimationTrigger(Player player, PlayerAttackState playerAttackState){
        Collider2D[] enemiesHit = Physics2D.OverlapCircleAll(player.attackPoint.position, attackRadius, whatIsDamagable);
        
        foreach (Collider2D enemy in enemiesHit) {
            enemy.transform.SendMessage("Damage", attackDetails);
        }
    }

    public override void AttackAnimationFinishTrigger(Player player, PlayerAttackState playerAttackState){
        // if (tempObj.transform.parent != null) {
        //     Destroy(tempObj.transform.parent.gameObject);
        // }
        // else if(tempObj != null){
        //     Destroy(tempObj);
        // }
        player.StateMachine.ChangeState(player.IdleState);
    }

    public override void SpellAnimationTrigger(Player player, PlayerSpellState playerSpellState){
        Collider2D[] enemiesHit = Physics2D.OverlapCircleAll(player.attackPoint.position, attackRadius, whatIsDamagable);
        
        foreach (Collider2D enemy in enemiesHit) {
            enemy.transform.SendMessage("Damage", attackDetails);
        }
    }

    public override void SpellAnimationFinishTrigger(Player player, PlayerSpellState playerSpellState){
        Destroy(tempObj);
        player.StateMachine.ChangeState(player.IdleState);
    }

    private void OnDrawGizmos() {
        
    }
}
