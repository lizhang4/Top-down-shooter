using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    public AttackDetails attackDetails;
    public Vector2 facingDirection;
    public bool playerAttack;
    public bool spin;
    public float spinSpeed = 100f;
    public float speed;
    public float maxTravelDistance;
    public float stayOnHitDuration;


    public float damageRadius;
    public Transform damagePosition;
    public Transform sprite;

    [SerializeField]
    private LayerMask 
        whatIsWall, 
        whatIsDamagable,
        whatIsPlayer,
        whatIsDestructible;


    private Vector2 startPos;
    private bool hasHitWall;
    private float hitTime;

    //References

    private Rigidbody2D rb;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();

        rb.gravityScale = 0f;
        rb.velocity = speed * facingDirection.normalized;
        startPos = transform.position;
        hasHitWall = false;

    } 

    private void Awake() {
        if(whatIsWall == LayerMask.GetMask("Nothing")) {
            whatIsWall += LayerMask.GetMask("Wall");

        }
        if(whatIsDamagable == LayerMask.GetMask("Nothing")) {
            whatIsDamagable += LayerMask.GetMask("Damagable");


        }
        if(whatIsPlayer == LayerMask.GetMask("Nothing")) {
            whatIsPlayer += LayerMask.GetMask("Player");


        }
        if(whatIsDestructible == LayerMask.GetMask("Nothing")) {
            whatIsDestructible += LayerMask.GetMask("Destructible");

        }

    }

    private void Update() {
        Vector2 newPos = new Vector2(transform.position.x, transform.position.y);
        // Destroy if out of max distance
        if(Mathf.Abs(Vector2.Distance(startPos, newPos)) >= maxTravelDistance ) {
            Destroy(gameObject);
            //TODO: Use obj pooling
        }


        // Destroy if hit wall while exceed stay duration
        if(hasHitWall && Time.time > hitTime + stayOnHitDuration){
            Destroy(gameObject);
            //TODO: Use obj pooling
        }
    }

    private void FixedUpdate() {
        if (!hasHitWall) {
            Collider2D damageHit;
            if (playerAttack) {
                damageHit = Physics2D.OverlapCircle(damagePosition.position, damageRadius, whatIsDamagable);
            }
            else {
                damageHit = Physics2D.OverlapCircle(damagePosition.position, damageRadius, whatIsPlayer);
            }
            Collider2D wallHit = Physics2D.OverlapCircle(damagePosition.position, damageRadius, whatIsWall);

            Collider2D destructibleHit = Physics2D.OverlapCircle(damagePosition.position, damageRadius, whatIsDestructible);

            if(damageHit) {
                damageHit.transform.SendMessage("Damage", attackDetails);
                Destroy(gameObject);
            }

            if(wallHit) {
                hasHitWall = true;
                rb.velocity = Vector2.zero;
                hitTime = Time.time;
            }

            if(destructibleHit) {
                hasHitWall = true;
                rb.velocity = Vector2.zero;
                hitTime = Time.time;
                destructibleHit.SendMessage("Destruct");
            }
        }

        Spin();

    }

    private void Spin() {
        if(spin && sprite != null){
            sprite.transform.Rotate(Vector3.forward, spinSpeed * Time.deltaTime);
        }
        
    }

    private void OnDrawGizmos() {
        Gizmos.DrawWireSphere(damagePosition.position, damageRadius);
    }
    

}
