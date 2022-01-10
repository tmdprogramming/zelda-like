using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour
{
    public int damageToGive = 2;
    public bool isHurt;
    public float wait =  1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isHurt)
        {
            wait -= Time.deltaTime;
            if(wait <= 0)
            {
                isHurt = false;
                wait = 1f;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy" && isHurt == false)
        {
            EnemyHealthManager eHealthMan;
            eHealthMan = other.gameObject.GetComponent<EnemyHealthManager>();
            eHealthMan.hurtEnemy(damageToGive);
            isHurt = true;
        }
    }
}
