using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FireBall01", menuName = "Assets/Skills/FireBall01")]
public class FireBall01 : SkillSO
{
    //public float damageCooldown = 0.5f;
    public float damageRadius = 2f;
    public LayerMask whatIsDamagable;
    public LayerMask whatIsBullet;
    private float lastDamageTime;


    //private AttackDetails attackDetails;
    public override void SkillStart(Skill skill)
    {
        base.SkillStart(skill);

        attackDetails.damageAmount = damage;
        
        if(skill.transform.parent != null) {
            attackDetails.damageAmount = skill.transform.parent.GetComponent<Skill>().skill.damage;
        }

        lastDamageTime = -10f;
    }

    public override void SkillUpdate(Skill skill)
    {
        base.SkillUpdate(skill);

        // if(lastDamageTime + damageCooldown < Time.time) {
        //     lastDamageTime = Time.time;
        //     Collider2D[] enemiesHit = Physics2D.OverlapCircleAll(skill.transform.position, damageRadius, whatIsDamagable);
        //     Collider2D[] bulletsHit = Physics2D.OverlapCircleAll(skill.transform.position, damageRadius, whatIsBullet);

        //     foreach(Collider2D enemy in enemiesHit) {
        //         enemy.SendMessage("Damage", attackDetails);
        //     }

        //     foreach(Collider2D bullet in bulletsHit) {
        //         Debug.Log("BulletDestroy");
        //         Destroy (bullet);
        //     }
        // }
    }

    public override void OnDrawSkillGizmos(Skill skill)
    {
        base.OnDrawSkillGizmos(skill);

        // Gizmos.color = Color.red;
        // Gizmos.DrawWireSphere(skill.transform.position, damageRadius);
    }
}
