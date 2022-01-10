using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class piano : MonoBehaviour
{
    public GameObject c_note;
    public GameObject d_note;
    public GameObject e_note;
    public GameObject f_note;
    public GameObject g_note;
    public GameObject a_note;
    public GameObject b_note;
    public GameObject c5_note;
    public GameObject c3_note;
    public GameObject d3_note;
    public GameObject e3_note;
    public GameObject f3_note;
    public GameObject g3_note;
    public GameObject a3_note;
    public GameObject b3_note;
    public GameObject c4s_note;
    public GameObject d4s_note;
    public GameObject f4s_note;
    public GameObject g4s_note;
    public GameObject a4s_note;
    public float noteTime;
    public bool playnote;
    public GameObject p;
    public GameObject Piano;
    public GameObject note;
    // Start is called before the first frame update
    void Start()
    {
        noteTime = .4f;
        
    }

    // Update is called once per frame
    void Update()
    {
     
        if (Input.GetKey(KeyCode.A))
        {
            c_note.SetActive(true);
            playnote = true;
          
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            c_note.SetActive(false);
        }
        if (Input.GetKey(KeyCode.S))
        {
            d_note.SetActive(true);
            playnote = true;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            d_note.SetActive(false);
            playnote = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            e_note.SetActive(true);
            playnote = true;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            e_note.SetActive(false);
            playnote = true;
        }
        if (Input.GetKey(KeyCode.F))
        {
            f_note.SetActive(true);
            playnote = true;
        }
        if (Input.GetKeyUp(KeyCode.F))
        {
            f_note.SetActive(false);
            playnote = true;
        }
        if (Input.GetKey(KeyCode.G))
        {
            g_note.SetActive(true);
            playnote = true;
        }
        if (Input.GetKeyUp(KeyCode.G))
        {
            g_note.SetActive(false);
            playnote = true;
        }
        if (Input.GetKey(KeyCode.H))
        {
            a_note.SetActive(true);
            playnote = true;
        }
        if (Input.GetKeyUp(KeyCode.H))
        {
            a_note.SetActive(false);
            playnote = true;
        }
        if (Input.GetKey(KeyCode.J))
        {
            b_note.SetActive(true);
            playnote = true;
        }
        if (Input.GetKeyUp(KeyCode.J))
        {
            b_note.SetActive(false);
            playnote = true;
        }
        if (Input.GetKey(KeyCode.K))
        {
            c5_note.SetActive(true);
            playnote = true;
        }
        if (Input.GetKeyUp(KeyCode.K))
        {
            c5_note.SetActive(false);
            playnote = true;
        }

        if (Input.GetKey(KeyCode.W))
        {
            c4s_note.SetActive(true);
            playnote = true;
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            c4s_note.SetActive(false);
            playnote = true;
        }

        if (Input.GetKey(KeyCode.E))
        {
            d4s_note.SetActive(true);
            playnote = true;
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            d4s_note.SetActive(false);
            playnote = true;
        }

        if (Input.GetKey(KeyCode.T))
        {
            f4s_note.SetActive(true);
            playnote = true;
        }
        if (Input.GetKeyUp(KeyCode.T))
        {
            f4s_note.SetActive(false);
            playnote = true;
        }

        if (Input.GetKey(KeyCode.Y))
        {
            g4s_note.SetActive(true);
            playnote = true;
        }
        if (Input.GetKeyUp(KeyCode.Y))
        {
            g4s_note.SetActive(false);
            playnote = true;
        }

        if (Input.GetKey(KeyCode.U))
        {
            a4s_note.SetActive(true);
            playnote = true;
        }
        if (Input.GetKeyUp(KeyCode.U))
        {
            a4s_note.SetActive(false);
            playnote = true;
        }






        if (Input.GetKey(KeyCode.Z))
        {
            c3_note.SetActive(true);
            playnote = true;

        }
        if (Input.GetKeyUp(KeyCode.Z))
        {
            c3_note.SetActive(false);
        }
        if (Input.GetKey(KeyCode.X))
        {
            d3_note.SetActive(true);
            playnote = true;
        }
        if (Input.GetKeyUp(KeyCode.X))
        {
            d3_note.SetActive(false);
            playnote = true;
        }
        if (Input.GetKey(KeyCode.C))
        {
            e3_note.SetActive(true);
            playnote = true;
        }
        if (Input.GetKeyUp(KeyCode.C))
        {
            e3_note.SetActive(false);
            playnote = true;
        }
        if (Input.GetKey(KeyCode.V))
        {
            f3_note.SetActive(true);
            playnote = true;
        }
        if (Input.GetKeyUp(KeyCode.V))
        {
            f3_note.SetActive(false);
            playnote = true;
        }
        if (Input.GetKey(KeyCode.B))
        {
            g3_note.SetActive(true);
            playnote = true;
        }
        if (Input.GetKeyUp(KeyCode.B))
        {
            g3_note.SetActive(false);
            playnote = true;
        }
        if (Input.GetKey(KeyCode.N))
        {
            a3_note.SetActive(true);
            playnote = true;
        }
        if (Input.GetKeyUp(KeyCode.N))
        {
            a3_note.SetActive(false);
            playnote = true;
        }
        if (Input.GetKey(KeyCode.M))
        {
            b3_note.SetActive(true);
            playnote = true;
        }
        if (Input.GetKeyUp(KeyCode.M))
        {
            b3_note.SetActive(false);
            playnote = true;
        }
       




        if (Input.GetKey(KeyCode.Tab))
        {
            p.SetActive(true);
            Piano.SetActive(false);
        }
        
    }

    private IEnumerator HandleIt()
    {
        playnote = true;
        // process pre-yield
        yield return new WaitForSeconds(1.0f);
        // process post-yield
        playnote = false;
    }
}
