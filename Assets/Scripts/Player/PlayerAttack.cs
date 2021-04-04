using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject bullet;
    public Transform attackPoint;
    public Vector2 facingDirection;
    public float facingAngle;
    public Vector3 worldPosition;
    
    public Weapon[] weapons;
    public int weaponCounter = 0;

    public float shootCooldown = 0.5f;
    public float dashCooldown = 0.5f;
    private float lastDashTime = 0f;
    private float lastAttackTime1 = 0f;
    public float lastAttackTime2 = 0f;
    private int weaponAttack = 0;
    private PlayerMovement playerMovement;

    private void Start() {
        playerMovement = GetComponent<PlayerMovement>();
        // if (weapons != null) {
        //     weapon = weapons[0];
        //     weaponCounter = 0;
        // }
        //weapon.AttackStart();
    }
    private void Update() {

        // if(Input.GetKeyDown(KeyCode.LeftShift)) {
        //     SwapWeapon();
        // }

        worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        facingDirection = new Vector2(worldPosition.x - transform.position.x, worldPosition.y - transform.position.y);
        facingDirection.Normalize();
        facingAngle = Vector2.SignedAngle(Vector2.up, facingDirection);
        transform.rotation = Quaternion.Euler(0,0,facingAngle);
        if (Input.GetMouseButton(0) && (lastAttackTime1 + 1/weapons[0].attackRate) < Time.time) {
            lastAttackTime1 = Time.time;
            weaponCounter = 0;
            //weapons[0].AttackLogicUpdate(this, playerMovement);
        }
        if (Input.GetMouseButton(1) && (lastAttackTime2 + 1/weapons[1].attackRate) < Time.time) {
            lastAttackTime2 = Time.time;
            weaponCounter = 1;
            //weapons[0].SpellLogicUpdate(this, playerMovement);
        }
    }

    

    // public void AttackAnimationTrigger() {
    //     MeleeWeapon meleeWeapon = (MeleeWeapon) weapons[weaponCounter];
    //     meleeWeapon.AttackAnimationTrigger(this, playerMovement);
    // }
    // public void AttackAnimationFinishTrigger(){
    //     MeleeWeapon meleeWeapon = (MeleeWeapon) weapons[weaponCounter];
    //     meleeWeapon.AttackAnimationFinishTrigger(this, playerMovement);
    // }

    // public void SpellAnimationTrigger() {
    //     MeleeWeapon meleeWeapon = (MeleeWeapon) weapons[weaponCounter];
    //     meleeWeapon.SpellAnimationTrigger(this, playerMovement);
    // }
    // public void SpellAnimationFinishTrigger(){
    //     MeleeWeapon meleeWeapon = (MeleeWeapon) weapons[weaponCounter];
    //     meleeWeapon.SpellAnimationFinishTrigger(this, playerMovement);
    // }

    private void OnDrawGizmos() {
        Gizmos.DrawWireSphere(attackPoint.position, 0.4f);
        if (weapons[weaponCounter].GetType().ToString() == "MeleeWeapon") {
            MeleeWeapon meleeWeapon = (MeleeWeapon)weapons[weaponCounter];
            Gizmos.DrawWireSphere(attackPoint.position, meleeWeapon.attackRadius);
        }
    }

    public void SwapWeapon() {
        if(weaponCounter == 0) {
            if (weapons[1] != null) {
                // weapon = weapons[1];
                weaponCounter = 1;
            }
        }
        else {
            if (weapons[0] != null) {
                // weapon = weapons[0];
                weaponCounter = 0;
            }
        }
    }

    public void PickWeapon() {
        
    }

}
