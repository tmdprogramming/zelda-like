using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pit : MonoBehaviour
{
    Animator player_animator;
    bool falling = false;
    GameObject falling_thing;
    float fall_time;
    float fall_timer;
    // Start is called before the first frame update
    void Start()
    {
        player_animator = FindObjectOfType<CharacterController2D>().GetComponent<Animator>();
        fall_time = 1.4f;
    }

    // Update is called once per frame
    void Update()
    {
        if (falling)
        {
          
            fall_time = fall_time - Time.deltaTime;
            if (fall_time <= 0)
            {
                if (player_animator.GetFloat("Look X") >= .5)
                {
                    falling_thing.transform.position = new Vector2(falling_thing.transform.position.x - 1f, falling_thing.transform.position.y);
                }
                if (player_animator.GetFloat("Look X") <= -.5)
                {
                    falling_thing.transform.position = new Vector2(falling_thing.transform.position.x + 1f, falling_thing.transform.position.y);
                }
                if (player_animator.GetFloat("Look Y") >= .5)
                {
                    falling_thing.transform.position = new Vector2(falling_thing.transform.position.x, falling_thing.transform.position.y - 1f);
                }
                if (player_animator.GetFloat("Look Y") <= -.5)
                {
                    falling_thing.transform.position = new Vector2(falling_thing.transform.position.x, falling_thing.transform.position.y + 1f);
                }
                fall_time = 1.4f;
                falling = false;
                falling_thing.gameObject.GetComponent<Animator>().SetBool("isfalling", false);
                falling_thing.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        if (other.GetComponent<Animator>().GetBool("jumping") == false)
        {
            other.gameObject.GetComponent<Animator>().SetBool("isfalling", true);
            falling_thing = other.gameObject;
            falling = true;

            other.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;

            if (player_animator.GetFloat("Look X") >= .5)
            {
                falling_thing.transform.position = new Vector2(falling_thing.transform.position.x + .5f, falling_thing.transform.position.y);
            }
            if (player_animator.GetFloat("Look X") <= -.5)
            {
                falling_thing.transform.position = new Vector2(falling_thing.transform.position.x - .5f, falling_thing.transform.position.y);
            }
            if (player_animator.GetFloat("Look Y") >= .5)
            {
                falling_thing.transform.position = new Vector2(falling_thing.transform.position.x, falling_thing.transform.position.y + .5f);
            }
            if (player_animator.GetFloat("Look Y") <= -.5)
            {
                falling_thing.transform.position = new Vector2(falling_thing.transform.position.x, falling_thing.transform.position.y - .5f);
            }
        }
    }
}
