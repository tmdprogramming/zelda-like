using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dark_matter : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    private float attackcounter = 1.3f;
    
    Animator player_animator;
    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        
        player_animator = FindObjectOfType<CharacterController2D>().GetComponent<Animator>();
    }

 

    void Update()
    {
       
            attackcounter -= Time.deltaTime;

            if (attackcounter <= 0)
            {
                Destroy(gameObject);
            }
        
    }
    private void OnTriggerExit2D(Collider2D other)
    {

        
            if (other.tag == "Movable" )
        {
            
           

            if (player_animator.GetFloat("Look X") == 1)
            {
                other.transform.position = new Vector2(other.transform.position.x + 1f, other.transform.position.y);
            }
            if (player_animator.GetFloat("Look X") == -1)
            {
                other.transform.position = new Vector2(other.transform.position.x - 1f, other.transform.position.y);
            }
            if (player_animator.GetFloat("Look Y") == 1)
            {
                other.transform.position = new Vector2(other.transform.position.x, other.transform.position.y + 1f);
            }
            if (player_animator.GetFloat("Look Y") == -1)
            {
                other.transform.position = new Vector2(other.transform.position.x, other.transform.position.y - 1f);
            }
        }
    }
    
        
    

}
