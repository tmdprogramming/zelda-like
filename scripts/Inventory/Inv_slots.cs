using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Inv_slots : MonoBehaviour
{
    public Item the_item_on_here;
    public Image button_image;
    public Sprite changeimage;
    public GameObject slot;
    
    public GameObject slot_item_image;
    public GameObject selector;
    public GameObject p;
    private void Start()
    {
        
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            //selector.SetActive(true);
            selector.SetActive(false);
            //this.GetComponent<Transform>().position = new Vector3(this.GetComponent<Transform>().position.x, this.GetComponent<Transform>().position.y + 1000, 0);
            gameObject.SetActive(false);
            p.SetActive(true);
            p.GetComponent<Animator>().SetFloat("lastMoveY", -1f);
        }
        if(Input.GetKeyDown(KeyCode.W) && selector.GetComponent<Transform>().position.y < 775f )
        {
            selector.GetComponent<Transform>().position = new Vector3(selector.GetComponent<Transform>().position.x, selector.GetComponent<Transform>().position.y + 150, 0);
        }
        if (Input.GetKeyDown(KeyCode.A) && selector.GetComponent<Transform>().position.x > 535f && selector)
        {
            selector.GetComponent<Transform>().position = new Vector3(selector.GetComponent<Transform>().position.x - 150, selector.GetComponent<Transform>().position.y, 0);
        }
        if (Input.GetKeyDown(KeyCode.S ) && selector.GetComponent<Transform>().position.y > 250f)
        {
            selector.GetComponent<Transform>().position = new Vector3(selector.GetComponent<Transform>().position.x, selector.GetComponent<Transform>().position.y -150, 0);
        }
        if (Input.GetKeyDown(KeyCode.D) && selector.GetComponent<Transform>().position.x < 1350f && selector)
        {
            selector.GetComponent<Transform>().position = new Vector3(selector.GetComponent<Transform>().position.x + 150, selector.GetComponent<Transform>().position.y, 0);
        }
    }
    
}
