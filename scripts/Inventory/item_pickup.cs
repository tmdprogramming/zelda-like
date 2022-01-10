using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class item_pickup : MonoBehaviour
{
    public Item pick_up;
    public Inv_slots inv;
    public GameObject inventory;
    public int id;
    // Start is called before the first frame update
    void Start()
    {
        inv = FindObjectOfType<Inv_slots>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameControl.control.id[id] == id)
        {
            GameObject icon = new GameObject();
            icon.AddComponent<Image>();
            icon.AddComponent<Rigidbody2D>();
            icon.AddComponent<BoxCollider2D>();
            icon.GetComponent<Rigidbody2D>().gravityScale = 0f;


            icon.transform.SetParent(inventory.transform);
            icon.GetComponent<Image>().sprite = pick_up.icon;
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            GameControl.control.id[id] = id;
            //inv.item_on_here(pick_up);
            Destroy(this.gameObject);

            GameObject icon = new GameObject();
            icon.AddComponent<Image>();
            icon.AddComponent<Rigidbody2D>();
            icon.AddComponent<BoxCollider2D>();
            icon.GetComponent<Rigidbody2D>().gravityScale = 0f;
            

            icon.transform.SetParent(inventory.transform);
            icon.GetComponent<Image>().sprite = pick_up.icon;
            //createImage.SetParent(this.gameObject, false);
            //slot.GetComponentInChildren<Image>().sprite = item_that_was_picked_up.icon;
        }
    }
}
