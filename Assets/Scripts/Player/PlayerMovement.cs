using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public float dashSpeed = 15.0f;
    public float dashDuration = 0.5f;
    public float dashCooldown = 1f;
    public Vector2 dir;

    [SerializeField]
    private Vector2 movementInput = Vector2.zero;
    [SerializeField]
    public bool dashInput = false;
    private Vector2 dashDirection;
    private float lastDashTime;
    
    private Rigidbody2D rb;
    private BoxCollider2D col;
    private PlayerAttack playerAttack;

    public bool gotAttackMovement = false;


    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
        playerAttack = GetComponent<PlayerAttack>();
        

    }

    private void Update() {
        movementInput.x = Input.GetAxisRaw("Horizontal");
        movementInput.y = Input.GetAxisRaw("Vertical");

        movementInput.Normalize();
        if(Input.GetKeyDown(KeyCode.Space) && (lastDashTime + dashCooldown < Time.time)) {
            dashInput = true;
            dashDirection = movementInput;
        }
    }

    private void FixedUpdate() {
        if (!gotAttackMovement) {
            Move();
            if(dashInput) {
                lastDashTime = Time.time;
                StartCoroutine(Dash());
            }
        }
    }

    private void Move() {
        rb.velocity = movementInput * speed;
    }

    private IEnumerator Dash() {
        rb.velocity = dashDirection * dashSpeed;
        yield return new WaitForSeconds(dashDuration);
        dashInput = false;
        rb.velocity = Vector2.zero;
    }

    public void SetVelocity(Vector2 dir, float speed) {
        rb.velocity = dir.normalized * speed;
    }

    public void SetVelocityZero() {
        rb.velocity = Vector2.zero;
    }


    

}
