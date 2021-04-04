using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FireWand", menuName = "Assets/RangeWeapon/FireWand")]
public class FireWand : NormalWand
{
    public float spellDuration = 3f;
    public float spellRadius = 3.5f;
    public LayerMask whatIsBullet;
    private float damageCooldown = 0.5f;
    private float lastDamageTime;

    

    private GameObject spellTempObj;
    public override void ApplyDebuff(ref AttackDetails attackDetails)
    {
        base.ApplyDebuff(ref attackDetails);
    }

    public override void SpellEnter(Player player, PlayerSpellState playerSpellState)
    {
        base.SpellEnter(player, playerSpellState);

        attackDetails.damageAmount = spellDamage;
        lastDamageTime = -10f;

        spellTempObj = Instantiate(spellEffect[0], player.transform);
        spellTempObj.GetComponent<Skill>().skill.attackDetails = attackDetails;
        spellTempObj.GetComponent<Skill>().skill.spellRadius = spellRadius;
        spellTempObj.GetComponent<Skill>().skill.damageCooldown = damageCooldown;
        spellTempObj.GetComponent<Skill>().skill.duration = spellDuration;


        //spellTempObj.GetComponent<Skill>().skill.damage = spellDamage;
    }

    public override void SpellExit(Player player, PlayerSpellState playerSpellState)
    {
        base.SpellExit(player, playerSpellState);
        lastSpellTime = playerSpellState.startTime + spellDuration;
    }

    public override void SpellLogicUpdate(Player player, PlayerSpellState playerSpellState)
    {
        base.SpellLogicUpdate(player, playerSpellState);
        // Collider2D[] bulletsHit = Physics2D.OverlapCircleAll(player.transform.position, spellRadius, whatIsBullet);
        // foreach (Collider2D bullet in bulletsHit) {
        //     Debug.Log("DetectedBullet");
        //     if(!bullet.GetComponent<Projectile>().playerAttack){
        //         Destroy(bullet.gameObject);
        //     }
        // }

        // if(lastDamageTime + damageCooldown < Time.time) {
        //     lastDamageTime = Time.time;
        //     Collider2D[] enemiesHit = Physics2D.OverlapCircleAll(player.transform.position, spellRadius, whatIsDamagable);
            

        //     foreach (Collider2D enemy in enemiesHit) {
        //         enemy.transform.SendMessage("Damage", attackDetails);
        //     }

            
        // }



        if (playerSpellState.startTime + spellDuration <= Time.time) {
            //player.ImmuneDamageOff();
            //Destroy(spellTempObj);
            player.StateMachine.ChangeState(player.IdleState);

        }

        
    }

    // public void SpellPhysicUpdate(Player player, PlayerSpellState playerSpellState) {
    //     Collider2D[] bulletsHit = Physics2D.OverlapCircleAll(player.transform.position, spellRadius, whatIsBullet);
    // }

    public override void WeaponGizmos(Player player)
    {
        base.WeaponGizmos(player);

        Gizmos.DrawWireSphere(player.transform.position, spellRadius);
    }


}
