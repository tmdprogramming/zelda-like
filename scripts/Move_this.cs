using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Move_this : MonoBehaviour
{
    private Animator myAnim;
    private Transform target;
    public Transform homePos;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float maxRange;
    [SerializeField]
    private float minRange;
    public bool onSpot;
    public Text NPC_SPEECH;
    [TextArea]
    public string words;
    public Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>();
        target = FindObjectOfType<CharacterController2D>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Vector3.Distance(target.position, transform.position) <= maxRange && Vector3.Distance(target.position, transform.position) >= minRange)
        //{
        //    followPlayer();
       //}
        //else if (Vector3.Distance(target.position, transform.position) >= maxRange)
       // {
            goHome();
        // }

        

    }
    public void followPlayer()
    {
        myAnim.SetBool("inMoving", true);
        myAnim.SetFloat("moveX", (target.position.x - transform.position.x));
        myAnim.SetFloat("moveY", (target.position.y - transform.position.y));
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }
    public void goHome()
    {
        myAnim.SetBool("inMoving", true);
        myAnim.SetFloat("moveX", (homePos.position.x - transform.position.x));
        myAnim.SetFloat("moveY", (homePos.position.y - transform.position.y));
        transform.position = Vector3.MoveTowards(transform.position, homePos.position, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, homePos.position) == 0)
        {
            myAnim.SetBool("inMoving", false);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //if (other.tag == "myweapon")
        //{
        //    Vector2 difference = transform.position - other.transform.position;
        //    transform.position = new Vector2(transform.position.x + difference.x, transform.position.y + difference.y);
       // }
        if (other.tag == "talk")
        {

            DisplayDialog();
        }
    }
    public void DisplayDialog()
    {
        //timerDisplay = displayTime;
        // dialogBox.SetActive(true);
        canvas.gameObject.SetActive(true);




        NPC_SPEECH.text = "";

        StartCoroutine(TypeText());
    }
    IEnumerator TypeText()
    {
        foreach (var letter in words.ToCharArray())
        {

            NPC_SPEECH.text += letter;
            int count = NPC_SPEECH.GetComponent<Text>().cachedTextGenerator.lineCount;
            
            if (count > 2)
            {
                yield return new WaitForSeconds(1f);
                NPC_SPEECH.text = "";

            }
            yield return new WaitForSeconds(.1f);
        }
    }
}
