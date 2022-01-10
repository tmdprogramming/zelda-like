using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NonPlayerCharacter : MonoBehaviour
{
    //public float displayTime = 1.0f;
    //public GameObject dialogBox;
    //float timerDisplay;
    public Text NPC_NAME;
    public Text NPC_SPEECH;
    public Canvas canvas;
    [TextArea]
    public string words;
    public string proper_name;
    public GameObject other;
    public Image bubble;
    public Image turner;
    public Sprite normal;
    private string word;
    public GameObject give;
    void Start()
    {
        //dialogBox.SetActive(false);
        //timerDisplay = -1.0f;
        
    }

    void Update()
    {
       /*if(Input.GetKeyDown(KeyCode.F))
        {
            canvas.gameObject.SetActive(false);
            other.gameObject.GetComponent<CharacterController2D>().enabled = true;
            NPC_SPEECH.text = words;
        }
       */
    }

    public void DisplayDialog()
    {
        //timerDisplay = displayTime;
        // dialogBox.SetActive(true);
        canvas.gameObject.SetActive(true);
        
        
        other.gameObject.GetComponent<CharacterController2D>().enabled = false;
        NPC_NAME.text = proper_name;
        
        
        NPC_SPEECH.text = "";
        
        StartCoroutine(TypeText());
    }
    IEnumerator TypeText()
    {
         foreach (var letter in words.ToCharArray())
        {
            
            NPC_SPEECH.text += letter;
            int count = NPC_SPEECH.GetComponent<Text>().cachedTextGenerator.lineCount;
            
            if(count>2)
            {
                yield return StartCoroutine(WaitForKeyDown(KeyCode.F));
                turner.GetComponent<Image>().sprite = normal;
                turner.GetComponent<Animator>().SetBool("turn", false);
                NPC_SPEECH.text = "";
                
            }
            yield return new WaitForSeconds(.1f);
        }
        yield return StartCoroutine(WaitForKeyDownExit(KeyCode.F));
        other.gameObject.GetComponent<CharacterController2D>().enabled = true;
        canvas.gameObject.SetActive(false);
        give.SetActive(true);
    }
    IEnumerator WaitForKeyDown(KeyCode keycode)
    {
        while (!Input.GetKeyDown(keycode))
        {
            turner.GetComponent<Animator>().SetBool("turn", true);
            yield return null;
        }
    }
    IEnumerator WaitForKeyDownExit(KeyCode keycode)
    {
        while (!Input.GetKeyDown(keycode))
        {
            turner.GetComponent<Animator>().SetBool("turn", true);
            yield return null;
        }
    }
}
