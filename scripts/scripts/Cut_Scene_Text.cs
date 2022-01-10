using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cut_Scene_Text : MonoBehaviour
{
    public GameObject dialogBox;
    public float displayTime = 10f;
    public bool begin;
    // Start is called before the first frame update
    void Start()
    {
        dialogBox.SetActive(true);
        displayTime = 10f;
        begin = true;
}

    // Update is called once per frame
    void Update()
    {
        if (begin) { 
        displayTime -= Time.deltaTime;
        if (displayTime <= 0)
        {
            Destroy(dialogBox);
                begin = false;
        }
        Debug.Log(displayTime);
    }
    }
}
