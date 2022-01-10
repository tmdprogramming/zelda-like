using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    Rigidbody2D body;
    private Animator myAnimator;
    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;

    public float runSpeed = 20.0f;
    private float attackTime = .25f;
    private float attackCounter = .25f;
    private bool isAttacking;
    public PlayerPosition startingPosition;
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        transform.position = startingPosition.initialValue;
    }

    void Update()
    {
        // Gives a value between -1 and 1
        horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
        vertical = Input.GetAxisRaw("Vertical"); // -1 is down
    }

    void FixedUpdate()
    {
        if (horizontal != 0 && vertical != 0) // Check for diagonal movement
        {
            // limit movement speed diagonally, so you move at 70% speed
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }

        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);

        myAnimator.SetFloat("moveX", body.velocity.x);
        myAnimator.SetFloat("moveY", body.velocity.y);

        if(Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1 )
        {
            myAnimator.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
            myAnimator.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));
        }
        if(isAttacking)
        {
            body.velocity = Vector2.zero;
            attackCounter -= Time.deltaTime;
            if(attackCounter <= 0)
            {
                myAnimator.SetBool("isAttacking", false);
                isAttacking = false;
            }
        }
        if(Input.GetKeyDown(KeyCode.T))
        {
            attackCounter = attackTime;
            myAnimator.SetBool("isAttacking", true);
            isAttacking = true;
        }
    }
}
