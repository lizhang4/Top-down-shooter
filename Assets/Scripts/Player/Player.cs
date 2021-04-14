using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region  States
    public PlayerStateMachine StateMachine {get; private set;}
    public PlayerIdleState IdleState {get; private set;}
    public PlayerMoveState MoveState {get; private set;}
    public PlayerAttackState AttackState {get; private set;}
    public PlayerSpellState SpellState {get; private set;}
    public PlayerAbilityState AbilityState {get; private set;}

    #endregion


    public PlayerData playerData;
    public Weapon weapon;
    public Ability ability;
    public PlayerStats playerStats;
    public Vector2 facingDirection;
    public Vector2 movementInput;
    public float facingAngle;
    public Vector3 worldPosition;

    //public reference
    public Animator anim;
    // Private data
    private Rigidbody2D rb;
    private Collider2D col;
    private SpriteRenderer spriteRenderer;


    [Header("Transforms")]
    public Transform attackPoint;
    public Transform rotatePoint;
    private Vector2 velocityWorkspace;

    private void Awake() {
        StateMachine = new PlayerStateMachine();

        IdleState = new PlayerIdleState(this, StateMachine, playerData, "Idle");
        MoveState = new PlayerMoveState(this, StateMachine, playerData, "Move");
        AttackState = new PlayerAttackState(this, StateMachine, playerData, "Attack");
        SpellState = new PlayerSpellState(this, StateMachine, playerData, "Spell");
        AbilityState = new PlayerAbilityState(this, StateMachine, playerData, "Ability");
    }

    public virtual void Start() {
        facingDirection = new Vector2(0,1);

        rb = GetComponent<Rigidbody2D>();
        
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerStats = GetComponent<PlayerStats>();
        weapon.InitialiseWeapon();
        ability.InitializeAbility();
        StateMachine.Initialize(this.IdleState);
    }


    public LayerMask whatIsItem;
    public float pickRadius = 2f;
    
    //references
    private PlayerAttack playerAttack;
    private PlayerMovement playerMovement;
    


    // Update is called once per frame
    void Update()
    {
        worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        facingDirection = new Vector2(worldPosition.x - transform.position.x, worldPosition.y - transform.position.y);
        facingDirection.Normalize();
        facingAngle = Vector2.SignedAngle(Vector2.up, facingDirection);
        rotatePoint.transform.rotation = Quaternion.Euler(0,0,facingAngle);

        if(Mathf.Abs(rb.velocity.x ) > 0.01 || Mathf.Abs(rb.velocity.y ) > 0.01) {
           anim.SetBool("Run", true);
        }
        else {
           anim.SetBool("Run", false);
            
        }


        StateMachine.currentState.LogicUpdate();
        // if(Mathf.Abs(rb.velocity.x) > 0.01 || rb.velocity.y > 0.01) {
        //     anim.SetBool("Down", false);
        //     anim.SetBool("Side", false);
        //     anim.SetBool("Run", true);
        //     anim.SetBool("Up", true);
        // }
        // else if(Mathf.Abs(rb.velocity.x) > 0.01 || rb.velocity.y < -0.01) {
        //     anim.SetBool("Up", false);
        //     anim.SetBool("Side", false);
        //     anim.SetBool("Run", true);
        //     anim.SetBool("Down", true);
        // }
        // else if(Mathf.Abs(rb.velocity.x) > 0.01 && Mathf.Abs(rb.velocity.y) < 0.01) {
        //     anim.SetBool("Down", false);
        //     anim.SetBool("Up", false);
        //     anim.SetBool("Run", true);
        //     anim.SetBool("Side", true);
        // }
        // else if(Mathf.Abs(rb.velocity.x) < 0.01 && Mathf.Abs(rb.velocity.y) < 0.01) {
        //     anim.SetBool("Run", false);
        // }
        
        // if(Input.GetKeyDown(KeyCode.F)) {
        //     PickItem();
        // }


    }

    public virtual void FixedUpdate() {
        StateMachine.currentState.PhysicUpdate();
    }


    #region SetFunctions
    public virtual void SetVelocity(Vector2 direction, float speed) {
        rb.velocity = direction.normalized * speed;
    }

    public virtual void SetVelocityZero() {
        rb.velocity = Vector2.zero;
    }

    public virtual void SetPosition(Vector2 position) {
        rb.position = new Vector3(position.x, position.y, 0);
    }
    #endregion

    #region GetFunctions
    // Duration is time for the damage taken period
    public virtual void GetDamageTaken(int initialHealth, float duration) {
        // playerStats.currentHealth
        // if(playerStats.currentHealth )
    }

    public virtual bool GetHit() {
        return playerStats.getHit;
    }

    public virtual void ImmuneDamageOn() {
        playerStats.immuneDamage = true;
    }

    public virtual void ImmuneDamageOff() {
        playerStats.immuneDamage = false;
    }

    public IEnumerator ImmuneDamageOn(float duration) {
        playerStats.immuneDamage = true;

        yield return new WaitForSeconds(duration);

        playerStats.immuneDamage = false;
    }

    public virtual Vector2 GetCursorPosition() {
        return worldPosition;
    }

    #endregion

    #region Buffs
    public IEnumerator MoveSpeedBuff(float newSpeed, float duration, float originalMoveSpeed) {
        playerData.moveSpeed = 20;
        yield return new WaitForSeconds(2);
        Debug.Log("OriSpeed");
        playerData.moveSpeed = 15;
    }


    #endregion

    #region Inputs


    #endregion



    #region Triggers

    public void AttackAnimationTrigger() {
        StateMachine.currentState.AnimationTrigger();
    }

    public void AttackAnimationFinishTrigger() {
        StateMachine.currentState.AnimationFinishTrigger();
    }

    public void SpellAnimationTrigger() {
        StateMachine.currentState.AnimationTrigger();
    }

    public void SpellAnimationFinishTrigger() {
        StateMachine.currentState.AnimationFinishTrigger();
    }

    #endregion







    public void PickItem() {
        Collider2D item = Physics2D.OverlapCircle(transform.position, pickRadius, whatIsItem);
        if (item != null) {
            Debug.Log(item.name);
            //Weapon itemComponentWeapon = item.transform.GetComponent<Item>().weapon;
            if (playerAttack.weapons[1] != null) {
                Weapon tempWeapon = playerAttack.weapons[1];
                playerAttack.weapons[1] = item.GetComponent<Item>().weapon;
                item.GetComponent<Item>().weapon = tempWeapon;
            }
            else {
                playerAttack.weapons[1] = item.GetComponent<Item>().weapon;
                Destroy(item.gameObject);
            }

        }
    }

    private void OnDrawGizmos() {
        //Gizmos.DrawWireSphere(transform.position, pickRadius);
        Gizmos.DrawWireSphere(attackPoint.position, 0.4f);
        Gizmos.color = Color.red;

        weapon.WeaponGizmos(this);
    }
}
