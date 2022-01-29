using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_mov : MonoBehaviour
{
    [SerializeField] float      speed = 1;
    private float               currentSpeed;
    [SerializeField] float      airdrag = 1;
    [SerializeField] float      gravityNorm = -9.8f;
    [SerializeField] float      gravityFall = -10;
    private Rigidbody2D         body;
    [SerializeField] float      jumpAceleration = 1;
    [SerializeField] float      jumpMaxSpeed = 2;
    private float               currentJumpSpeed = 0;
    private bool                chargingJump = false;
    [SerializeField] LayerMask  groundLayers;
    private BoxCollider2D       groundCheck;
    [SerializeField] bool       grounded;
    private Animator            animationController;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        groundCheck = GetComponent<BoxCollider2D>();
        animationController = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (grounded)
            currentSpeed = Input.GetAxis("Horizontal") * speed;
        else
            currentSpeed = Input.GetAxis("Horizontal") * (speed- airdrag);


        if (currentSpeed < -0.005)
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        else if (currentSpeed > 0.005)
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        
        body.velocity = new Vector2(currentSpeed, body.velocity.y);


        if (chargingJump)
        {
            currentJumpSpeed += jumpAceleration;
            if (currentJumpSpeed > jumpMaxSpeed)
                currentJumpSpeed = jumpMaxSpeed;
        }



        animationController.SetFloat("speedX",Mathf.Abs( body.velocity.x));
        animationController.SetFloat("speedY", body.velocity.y);
    }

    private void Update()
    {
        grounded = isGrounded();

        if (Input.GetButtonDown("Jump"))
            chargingJump = true;

        if (Input.GetButtonUp("Jump") && chargingJump && grounded)
        {
            body.AddForce(Vector2.up * currentJumpSpeed, ForceMode2D.Impulse);
            currentJumpSpeed = 0;
            chargingJump = false;
        }

        if (body.velocity.y >= 0 && !grounded)
            body.gravityScale = gravityNorm;
        else
            body.gravityScale = gravityFall;
    }

    private bool isGrounded()
    {
        RaycastHit2D rayHit = Physics2D.BoxCast(groundCheck.bounds.center, groundCheck.bounds.size, 0f, Vector2.down, 0.1f, groundLayers);
        return rayHit.collider != null;
    }
}
