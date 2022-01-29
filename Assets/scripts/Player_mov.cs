using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_mov : MonoBehaviour
{
    [SerializeField] float      speed = 1;
    private float               currentSpeed;
    [SerializeField] float      drag = 1;
    [SerializeField] float      gravityNorm = -9.8f;
    [SerializeField] float      gravityFall = -10;
    private Rigidbody2D         body;
    [SerializeField] float      jumpAceleration = 1;
    [SerializeField] float      jumpMaxSpeed = 2;
    private float               currentJumpSpeed = 0;
    private bool                chargingJump = false;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        currentSpeed = Input.GetAxis("Horizontal") * (speed - drag);
        Vector2 newpos = gameObject.transform.position;

        newpos.x += currentSpeed;

        if (currentSpeed < -0.005)
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        else if (currentSpeed > 0.005)
            gameObject.GetComponent<SpriteRenderer>().flipX = false;

        body.MovePosition(newpos);

        if (chargingJump)
        {
            currentJumpSpeed += jumpAceleration;
            if (currentJumpSpeed > jumpMaxSpeed)
                currentJumpSpeed = jumpMaxSpeed;
        }
            
        
        

        print(currentJumpSpeed);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
            chargingJump = true;

        if (Input.GetButtonUp("Jump") && chargingJump)
        {
            body.AddForce(new Vector2(0, currentJumpSpeed*10), ForceMode2D.Impulse);
            currentJumpSpeed = 0;
            chargingJump = false;
        }
    }
}
