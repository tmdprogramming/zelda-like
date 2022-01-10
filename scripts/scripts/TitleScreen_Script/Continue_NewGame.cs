using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;
public class Continue_NewGame : MonoBehaviour
{
    public float waitTime;
    [Serializable]
    class SaveData
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        waitTime = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            //highlight new game
            //link this to method that switches to sample scene with the same key press
            newGame();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            //highlight new game
            //link this to method that switches to sample scene with the same key press
            LoadGame();
        }
    }
    void newGame()
    {
        
       
     SceneManager.LoadScene("SampleScene");
          
    }
    void LoadGame()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            GameControl.control.Load();
            SceneManager.LoadScene(GameControl.control.scene);
           
        }
    }
}
