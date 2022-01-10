using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump_Ability : MonoBehaviour
{
    public float jump_timer;
    public float jump_count;
    public GameObject jumping_object;
    public GameObject object_jumped_over;
    Animator player_animator;
    public bool is_Jumping;
    public bool collided;
    
    // Start is called before the first frame update
    void Start()
    {
        player_animator = FindObjectOfType<CharacterController2D>().GetComponent<Animator>();
        is_Jumping = false;
        jump_timer = 1.2f;
        jump_count = 0f;
       
       
    }

    // Update is called once per frame
    void Update()
    {
        
        if (player_animator.GetBool("jumping"))
        {
            
            
            is_Jumping = true;
            
        }
        if(is_Jumping)
        {
            if (collided)
            {
                object_jumped_over.GetComponent<Collider2D>().enabled = false;
            }
            jump_count = jump_count + Time.deltaTime;
           
            if (jump_count >= jump_timer)
   
            {
                if (!collided)
                {
                    object_jumped_over.GetComponent<Collider2D>().enabled = true;
                }
                player_animator.SetBool("jumping", false);
                is_Jumping = false;
                jump_timer = 1.2f;
                jump_count = 0f;
            }
        }
        if(is_Jumping == false && this.gameObject.GetComponent<Rigidbody2D>().IsTouchingLayers(6))
        {
            this.gameObject.transform.position = new Vector2(this.gameObject.transform.position.x + 5, this.gameObject.transform.position.y);
        }
    }
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "jumpable")
            object_jumped_over = other.gameObject;
        if (is_Jumping)
        {
            object_jumped_over.GetComponent<Collider2D>().enabled = false;
        }

    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "jumpable")
            object_jumped_over = other.gameObject;
        if (is_Jumping)
        {
            object_jumped_over.GetComponent<Collider2D>().enabled = false;
        }
    }
    public void OnCollisionEnter2D()
    {
        collided = true;
    }

    public void OnCollisionExit2D()
    {
        collided = false;
    }
}
