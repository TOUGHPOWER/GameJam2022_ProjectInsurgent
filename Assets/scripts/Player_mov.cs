using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_mov : MonoBehaviour
{
    public float      speed = 1;
    private float               currentSpeed;
    [SerializeField] float      airdrag = 1;
    [SerializeField] float      gravityNorm = -9.8f;
    [SerializeField] float      gravityFall = -10;
    private Rigidbody2D         body;
    [SerializeField] float      jumpAceleration = 1;
    public float                jumpMaxSpeed = 2;
    [SerializeField] float      jumpMin = 1;
    private float               currentJumpSpeed = 0;
    private bool                chargingJump = false;
    [SerializeField] LayerMask  groundLayers;
    private CircleCollider2D    groundCheck;
    [SerializeField] bool       grounded;
    public Animator             animationController;
    public bool                 chargjump=true;
    private BoxCollider2D       wallCheck;


    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        groundCheck = GetComponent<CircleCollider2D>();
        wallCheck = GetComponent<BoxCollider2D>();
        //animationController = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (grounded)
            currentSpeed = Input.GetAxis("Horizontal") * speed;
        else
            currentSpeed = Input.GetAxis("Horizontal") * (speed- airdrag);


        if (currentSpeed < -0.005)
            gameObject.transform.eulerAngles = new Vector3(0, 180, 0);
        else if (currentSpeed > 0.005)
            gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
        if (!isWalled())
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

        if (Input.GetButtonDown("Jump") && grounded) 
        {
            if(!chargjump)
                body.AddForce(Vector2.up * jumpMaxSpeed, ForceMode2D.Impulse);
            else
                chargingJump = true;
        }
            

        if (Input.GetButtonUp("Jump") && chargingJump && grounded)
        {
            body.AddForce(Vector2.up * currentJumpSpeed, ForceMode2D.Impulse);
            currentJumpSpeed = jumpMin;
            chargingJump = false;
        }

        if (body.velocity.y >= 0 && !grounded)
            body.gravityScale = gravityNorm;
        else
            body.gravityScale = gravityFall;

    }

    private bool isGrounded()
    {
        RaycastHit2D rayHit = Physics2D.CircleCast(groundCheck.bounds.center, groundCheck.radius, Vector2.down, 0.1f, groundLayers);
        return rayHit.collider != null;
    }

    private bool isWalled()
    {
        RaycastHit2D rayHit = Physics2D.BoxCast(wallCheck.bounds.center, wallCheck.bounds.size, 0f, Vector2.left, 0.1f, groundLayers);
        return rayHit.collider != null;
    }
}
