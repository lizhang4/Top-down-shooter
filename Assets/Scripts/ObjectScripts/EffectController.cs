using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectController : MonoBehaviour
{
    // if effect duration is 0 means last forever
    public float effectDuration = 0;
    public Transform attackPoint;
    public float attackRadius;
    public LayerMask whatIsBullet;
    private float effectStartTime;



    void Start()
    {
        effectStartTime = Time.time;
    }
    void Update()
    {
        if (effectDuration != 0) {
            if(effectStartTime + effectDuration < Time.time) {
                Destroy(gameObject);
            }
        }

        Collider2D[] bullets = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius, whatIsBullet);

        foreach (Collider2D bullet in bullets) {
            if(!bullet.GetComponent<Projectile>().playerAttack) {
                Destroy(bullet.gameObject);
            }
        }

    }

    private void OnDrawGizmos() {
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }
}
