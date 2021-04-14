using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityStats : MonoBehaviour
{
    // [SerializeField] 
    // protected GameObject
    //     deathChunkParticle,
    //     deathBloodParticle;
    

    [SerializeField]
    public int currentHealth;
    public int currentShield;
    public bool immuneDamage = false;
    public bool GetDamageTaken = false;
    public bool getHit = false;
    public float getHitResetDuration = 0.25f;


    [Header("Debuffs")]
    public bool isFroze = false;
    public bool isBurned = false;
    public bool isShocked = false;

    //[SerializeField]

    private float lastDebuffTime = 0f;
    private float debuffDuration = 1f;

    //protected GameManager GM;

    protected virtual void Start() {
        //GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    protected virtual void Update() {
        if(isFroze || isBurned || isShocked) {
            if (lastDebuffTime + debuffDuration <= Time.time) {
                RemoveDebuff();
            }
        }

    }

    public virtual void Damage(AttackDetails attackDetails) {
        if (!immuneDamage) {
            currentHealth -= attackDetails.damageAmount;

            if (currentHealth <= 0.0f) {
                Die();
            }
        }

        if (attackDetails.damageAmount > 0) {
            StartCoroutine(GetHit());
        }
        else {
            getHit = false;
        }

        if(attackDetails.freeze) {
            isFroze = true;
        }
        else if(attackDetails.shock) {
            isShocked = true;
        }
        else if(attackDetails.burn) {
            isBurned = true;
        }

        Debuff();


    }




    protected virtual void Die() {
        //Instantiate(deathChunkParticle, transform.position, deathChunkParticle.transform.rotation);
        //Instantiate(deathBloodParticle, transform.position, deathBloodParticle.transform.rotation);
    
        //GM.Respawn();
        Destroy(gameObject);
    }

    protected virtual void Debuff() {
        lastDebuffTime = Time.time;
        if (isFroze) {
            Debug.Log("isFroze");
        }
        else if(isShocked) {
            Debug.Log("isShocked");
        }
        else if(isBurned) {
            Debug.Log("isBurned");
        }
    }

    protected virtual void RemoveDebuff() {
        isFroze = false;
        isBurned = false;
        isBurned = false;

        Debug.Log("RemoveDebuff");
    }

    protected IEnumerator GetHit() {
        getHit = true;

        yield return new WaitForSeconds(getHitResetDuration);
        getHit = false;
    }
}
