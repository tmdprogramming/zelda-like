using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    float time_to_burn;
    bool burning;
    GameObject burn_object;
    Vector2 spawnLocation;
    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        time_to_burn = 3f;
        burning = false;
        spawnLocation = this.gameObject.transform.position;
    }

    public void Launch(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force);
    }

    void Update()
    {
        
        
        if (transform.position.magnitude > 1000.0f)
        {
            Destroy(gameObject);
        }
        if(burning)
        {
            time_to_burn = time_to_burn - Time.deltaTime;
            if (time_to_burn <= 0)
            {
                Destroy(burn_object);
                burning = false;
                Destroy(this.gameObject);
            }
        }
        if (Vector2.Distance(spawnLocation, this.gameObject.transform.position) > 2)
        {
            Destroy(this.gameObject);
        }


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("burnable") == true)
        {
            burning = true;
            burn_object = collision.gameObject;
        }
    }


}





