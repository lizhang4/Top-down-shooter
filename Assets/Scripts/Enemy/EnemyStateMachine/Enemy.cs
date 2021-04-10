using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region States
    public EnemyStateMachine StateMachine {get; private set;}
    public EnemyIdleState IdleState {get; private set;}
    public EnemyMoveState MoveState {get; private set;}
    public EnemyPlayerDetectedState PlayerDetectedState {get; private set;}
    public EnemyLookingForPlayerState LookingForPlayerState {get; private set;}
    public EnemyAttack1State Attack1State {get; private set;}
    public EnemyAttack2State Attack2State {get ; private set;}
    public EnemyPatrolState PatrolState {get ; private set; }


    #endregion
    public EnemyData enemyData;

    public Vector2 facingDirection;
    public float facingAngle;
    public EnemyStats enemyStats;
    public EnemyAbility[] enemyAttack = new EnemyAbility[2];
    private Rigidbody2D rb;


    [SerializeField]
    private Transform playerCheck;
    public Transform attackPoint;

    private Vector2 velocityWorkspace;
    protected bool isDead;



    public E_IdleSO idleSO;
    public E_MoveSO moveSO;
    public E_AttackSO attackSO;
    public E_PatrolSO patrolSO;


    private void Awake() {
        StateMachine = new EnemyStateMachine();

        IdleState = new EnemyIdleState(this, StateMachine, enemyData, "Idle");
        MoveState = new EnemyMoveState(this, StateMachine, enemyData, "Move");
        PlayerDetectedState = new EnemyPlayerDetectedState(this, StateMachine, enemyData, "PlayerDetected");
        LookingForPlayerState = new EnemyLookingForPlayerState(this, StateMachine, enemyData, "LookForPlayer");
        Attack1State = new EnemyAttack1State(this, StateMachine, enemyData, "Attack1");
        Attack2State = new EnemyAttack2State(this, StateMachine, enemyData, "Attack2");
        PatrolState = new EnemyPatrolState(this, StateMachine, enemyData, "Patrol");

    }

    public virtual void Start() {
        facingDirection = new Vector2(0,1);
        //currentHealth = enemyData.maxHealth;

        rb = GetComponent<Rigidbody2D>();
        enemyStats = GetComponent<EnemyStats>();

        attackSO.InitializeLastAttackTime(this, Attack1State);
        StateMachine.Initialize(this.IdleState);

    }

    public virtual void Update() {
        if( GetPlayerPosition() != (Vector2)transform.position) {
            facingDirection = GetPlayerPosition() - (Vector2)transform.position;
            facingDirection.Normalize();
            facingAngle = Vector2.SignedAngle(Vector2.up, facingDirection);
            transform.rotation = Quaternion.Euler(0,0,facingAngle);
        }

        StateMachine.currentState.LogicUpdate();
        
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

    public virtual void MoveToPlayer() {
        rb.position = Vector2.MoveTowards(transform.position, GetPlayerPosition(), enemyData.moveSpeed * Time.deltaTime);
    }

    public virtual void MoveAwayFromPlayer() {
        rb.position = Vector2.MoveTowards(transform.position, GetPlayerPosition(), -enemyData.moveSpeed * Time.deltaTime);
    }
    

    #endregion

    #region DamageFunctions


    #endregion


    #region CheckFunctions
    public virtual bool CheckPlayerInDetectedRange(){
        return Physics2D.OverlapCircle(transform.position, enemyData.playerDetectedRadius, enemyData.whatIsPlayer);
    }

    public virtual bool CheckPlayerInMaxAgroRange() {
        return Physics2D.OverlapCircle(transform.position, enemyData.maxAgroRadius, enemyData.whatIsPlayer);
    }

    public virtual bool CheckPlayerInCloseRange(){
        return Physics2D.OverlapCircle(transform.position, enemyData.closeRangeActionRadius, enemyData.whatIsPlayer);
    }

    public virtual bool CheckPlayerInMidRange() {
        return Physics2D.OverlapCircle(transform.position, enemyData.midRangeActionRadius, enemyData.whatIsPlayer);
    }

    public virtual bool CheckPlayerInRetreatRange() {
        return Physics2D.OverlapCircle(transform.position, enemyData.retreatRangeRadius, enemyData.whatIsPlayer);
    }

    #endregion

    #region GetFunctions 
    public virtual Vector2 GetPlayerPosition() {
        Collider2D player = Physics2D.OverlapCircle(transform.position, enemyData.maxAgroRadius, enemyData.whatIsPlayer);
        if (player != null) {
            Vector2 playerPos = player.transform.position;
            return playerPos;
        }
        else {
            return transform.position;
        }
    }

    public virtual float GetDistanceBetweenPlayer() {
        Vector2 playerPos = GetPlayerPosition();

        return Mathf.Abs(Vector2.Distance(transform.position, playerPos));

    }
    //TODO: GetPlayerDirection()
    // public virtual Vector2 GetPlayerDirection() {

    // }

    #endregion

    #region Triggers

    public void AnimationTrigger() {
        StateMachine.currentState.AnimationTrigger();
    }

    public void AnimationFinishTrigger() {
        StateMachine.currentState.AnimationFinishTrigger();
    }

    #endregion

    public virtual void OnDrawGizmos() {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, enemyData.maxAgroRadius);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, enemyData.playerDetectedRadius);
        Gizmos.DrawWireSphere(transform.position, enemyData.midRangeActionRadius);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, enemyData.retreatRangeRadius);
        Gizmos.DrawWireSphere(transform.position, enemyData.closeRangeActionRadius);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(attackPoint.position, 0.3f);

    }


}
