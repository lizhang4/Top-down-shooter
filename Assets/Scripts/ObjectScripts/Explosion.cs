using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float explosionRadius;
    public AttackDetails attackDetails;
    public bool playerAttack;

    public LayerMask whatIsDamagable;
    public LayerMask whatIsDestructible;
    public LayerMask whatIsPlayer;

    private void Awake() {
        // whatIsDamagable = LayerMask.GetMask("Damagable");
        // whatIsDestructible = LayerMask.GetMask("Destructible");

    }


    private void Start() {
        Collider2D[] damagableHits = Physics2D.OverlapCircleAll(transform.position, explosionRadius, whatIsDamagable);
        Collider2D[] destructibleHits = Physics2D.OverlapCircleAll(transform.position, explosionRadius, whatIsDestructible);
        if(!playerAttack) {
            Collider2D playerHit = Physics2D.OverlapCircle(transform.position, explosionRadius, whatIsPlayer);
            if(playerHit != null) {
                playerHit.transform.SendMessage("Damage", attackDetails);

            }
        }

        foreach (Collider2D hit in damagableHits) {
            Debug.Log("hit");
            hit.transform.SendMessage("Damage", attackDetails);
        }

        foreach (Collider2D hit in destructibleHits) {
            hit.transform.SendMessage("Destruct");
        }
    }
}
