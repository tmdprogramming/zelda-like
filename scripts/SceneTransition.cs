using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneTransition : MonoBehaviour
{
    public string sceneToLoad;
    public Vector2 playerPositions;
    public PlayerPosition playerStorage;
    public bool destroy = false;
    public GameObject destroyMe;
    public int id;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            playerStorage.initialValue = playerPositions;
            SceneManager.LoadScene(sceneToLoad);
            GameControl.control.id[id] = id;
            
        }
    }
    private void Update()
    {
        // destroy transition to dream 1
        if (GameControl.control.id[id] == id)
        {
           
            Destroy(destroyMe);
        }
       
    }
}
