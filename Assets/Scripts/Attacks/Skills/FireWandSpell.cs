using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FireWandSpell", menuName = "Assets/Skills/FireWandSpell")]
public class FireWandSpell : SkillSO
{
    
    public float rotationSpeed = 5f;
    public LayerMask whatIsBullet;
    public LayerMask whatIsDamagable;

    private float lastDamageTime;
    private float startTime;
    

    public override void SkillStart(Skill skill)
    {
        base.SkillStart(skill);
        startTime = Time.time;
        lastDamageTime = -10f;
    }

    public override void SkillUpdate(Skill skill)
    {
        base.SkillStart(skill);
        skill.transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);

        Collider2D[] bulletsHit = Physics2D.OverlapCircleAll(skill.transform.position, spellRadius, whatIsBullet);
        foreach (Collider2D bullet in bulletsHit) {
            Debug.Log("DetectedBullet");
            if(!bullet.GetComponent<Projectile>().playerAttack){
                Destroy(bullet.gameObject);
            }
        }

        if(lastDamageTime + damageCooldown < Time.time) {
            lastDamageTime = Time.time;
            Collider2D[] enemiesHit = Physics2D.OverlapCircleAll(skill.transform.position, spellRadius, whatIsDamagable);
            

            foreach (Collider2D enemy in enemiesHit) {
                enemy.transform.SendMessage("Damage", attackDetails);
            }

            
        }

        if (startTime + duration <= Time.time) {
            //player.ImmuneDamageOff();
            Destroy(skill.gameObject);
        }
    }
}
