using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class selector : MonoBehaviour
{
    public GameObject vButton;
    public GameObject bButton;
    public Sprite place_holder;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            vButton.GetComponent<Image>().sprite = place_holder;
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            bButton.GetComponent<Image>().sprite = place_holder;
        }
    }
   
   
    private void OnTriggerEnter2D(Collider2D other)
    {
        
                place_holder = other.gameObject.GetComponent<Image>().sprite;
          
        
    }
    
}
