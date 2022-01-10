using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exit_the_water : MonoBehaviour
{


    Animator player_animator;





    void Start()
    {

        player_animator = FindObjectOfType<CharacterController2D>().GetComponent<Animator>();

    }


    // Update is called once per frame

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player") == true)
        {

            player_animator.SetBool("swimming", false);
            if (player_animator.GetFloat("Look X") >= .5)
            {
                other.transform.position = new Vector2(other.transform.position.x + 1f, other.transform.position.y);
            }
            if (player_animator.GetFloat("Look X") <= -.5)
            {
                other.transform.position = new Vector2(other.transform.position.x - 1f, other.transform.position.y);
            }
            if (player_animator.GetFloat("Look Y") >= .5)
            {
                other.transform.position = new Vector2(other.transform.position.x, other.transform.position.y + 1f);
            }
            if (player_animator.GetFloat("Look Y") <= -.5)
            {
                other.transform.position = new Vector2(other.transform.position.x, other.transform.position.y - 1f);
            }
        }
    }
}


    
