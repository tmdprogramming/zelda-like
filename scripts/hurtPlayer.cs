using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class hurtPlayer : MonoBehaviour
{
    private healthManager healthMan;
    public float waitToHurt = 1f;
    public bool isTouching;
    [SerializeField]
    private int damageToGive = 10;
    // Start is called before the first frame update
    void Start()
    {
        healthMan = FindObjectOfType<healthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //if(reloading)
       // {
         //   waitToLoad -= Time.deltaTime;
        //    if(waitToLoad <= 0)
       //     {
        //    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //    }
      //  }

      if(isTouching)
      {
          waitToHurt -= Time.deltaTime;
          if(waitToHurt<=0)
          {
            healthMan.hurtPlayer(damageToGive);
            waitToHurt = 1f;
          }
      }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
           // Destroy(other.gameObject);
           //other.gameObject.SetActive(false);
           other.gameObject.GetComponent<healthManager>().hurtPlayer(damageToGive);
          // reloading = true;
          
        }
        
    }
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
            isTouching = true;
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
            isTouching = false;
            waitToHurt = 1f;
        }
    }
}
