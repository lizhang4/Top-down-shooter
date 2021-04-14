using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IceWandSpell", menuName = "Assets/Skills/IceWandSpell")]

public class IceWandSpell : SkillSO
{
    public LayerMask whatIsBullet;
    public LayerMask whatIsDamagable;

    private float startTime;
    

    public override void SkillStart(Skill skill)
    {
        base.SkillStart(skill);
        startTime = Time.time;
        
        player.StartCoroutine(player.ImmuneDamageOn(duration));

    }

    public override void SkillUpdate(Skill skill) {
        base.SkillStart(skill);

        // if(player != null) {

            if (player.GetHit()) {
                Collider2D[] enemiesHit = Physics2D.OverlapCircleAll(player.transform.position, spellRadius, whatIsDamagable);

                attackDetails.freeze = true;
                foreach (Collider2D enemy in enemiesHit) {
                    enemy.transform.SendMessage("Damage", attackDetails);
                }

                player.weapon.SetLastSpellTime(Time.time);
                Destroy(skill.gameObject);
            }

            if (startTime + duration <= Time.time) {
                
                player.weapon.SetLastSpellTime(Time.time);
                Destroy(skill.gameObject);
            }
        // }
        // else {
        //     Debug.Log("NoPlayer");
        // }

    }

    // public override void SkillUpdate(Skill skill)
    // {
    //     base.SkillStart(skill);

    //     Collider2D[] bulletsHit = Physics2D.OverlapCircleAll(skill.transform.position, spellRadius, whatIsBullet);
    //     foreach (Collider2D bullet in bulletsHit) {
    //         Debug.Log("DetectedBullet");
    //         if(!bullet.GetComponent<Projectile>().playerAttack){
    //             Destroy(bullet.gameObject);
    //         }
    //     }

    //     if(lastDamageTime + damageCooldown < Time.time) {
    //         lastDamageTime = Time.time;
    //         Collider2D[] enemiesHit = Physics2D.OverlapCircleAll(skill.transform.position, spellRadius, whatIsDamagable);
            

    //         foreach (Collider2D enemy in enemiesHit) {
    //             enemy.transform.SendMessage("Damage", attackDetails);
    //         }

            
    //     }

    //     if (startTime + duration <= Time.time) {
    //         //player.ImmuneDamageOff();
    //         Destroy(skill.gameObject);
    //     }
    // }
}
