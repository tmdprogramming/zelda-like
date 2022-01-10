using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
[Serializable]
public class CharacterController2D : MonoBehaviour
{
    public float speed = 3.0f;

    public int maxHealth = 5;
    public Canvas Inventory;
    public GameObject projectilePrefab;
    public GameObject bubble_Prefab;
    public Image vbutton;
    public Image bbutton;
    public int health { get { return currentHealth; } }
    public Position my_position;

    int currentHealth;

    public float timeInvincible = 2.0f;
    bool isInvincible;
    float invincibleTimer;

    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;

    Animator animator;
    Vector2 lookDirection = new Vector2(0, -1);
    private float attacktime = .5f;
    private float attackcounter = .5f;
    private bool isattacking;
    public GameObject piano;
    public GameObject inv;
    public GameObject selector;
    public int scene_startx = 76;
    public int scene_starty = -117;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
        gameObject.transform.position = new Vector3(GameControl.control.x = scene_startx, GameControl.control.y = scene_starty, GameControl.control.z);
        animator.SetFloat("lastMoveY", -1f);

    }
    

    // Update is called once per frame
    void Update()
    {
        //open inventory
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            
            //inv.GetComponent<Transform>().position = new Vector3(inv.GetComponent<Transform>().position.x,inv.GetComponent<Transform>().position.y - 2000, 0);
            selector.SetActive(true);
            inv.SetActive(true);
            gameObject.SetActive(false);
        }

        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(horizontal, vertical);
        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            animator.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
            animator.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));
        }
        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }

        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);

        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            if (vbutton.sprite.name == "fire_spell_0")
            {
                Launch();
            }
            if (vbutton.sprite.name == "dark_matter_bubble_fiix_0")
            {
                Debug.Log("here");
                darkMatter();
            }
            if (vbutton.sprite.name == "PNG image 3_0" && isattacking != true)
            {
                attack();
            }
            if (vbutton.sprite.name == "carpet")
            {
                animator.SetBool("jumping", true);
            }
            if (vbutton.sprite.name == "piano")
            {
                piano.SetActive(true);
                this.gameObject.SetActive(false);
            }
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (bbutton.sprite.name == "fire_spell_0")
            {
                Launch();
            }
            if (bbutton.sprite.name == "dark_matter_bubble_fiix_0")
            {
                Debug.Log("here");
                darkMatter();
            }
            if (bbutton.sprite.name == "PNG image 3_0" && isattacking != true)
            {
                attack();
            }
            if (bbutton.sprite.name == "carpet")
            {
                animator.SetBool("jumping", true);
            }
            if (bbutton.sprite.name == "piano")
            {
                piano.SetActive(true);
                this.gameObject.SetActive(false);
            }
        }


        if (isattacking)
        {
            attackcounter -= Time.deltaTime;
           
            if (attackcounter <= 0)
            {
                animator.SetBool("attack", false);
                isattacking = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            RaycastHit2D hit = Physics2D.Raycast(rigidbody2d.position + Vector2.up * 0.2f, lookDirection, 1.5f, LayerMask.GetMask("NPC"));
            if (hit.collider != null)
            {
                NonPlayerCharacter character = hit.collider.GetComponent<NonPlayerCharacter>();
                if (character != null)
                {
                    character.DisplayDialog();
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            my_position.Positon1(gameObject.GetComponent<Transform>());
            GameControl.control.scene = SceneManager.GetActiveScene().name;
            GameControl.control.Save();
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            GameControl.control.Load();
            gameObject.transform.position = new Vector3(GameControl.control.x, GameControl.control.y, GameControl.control.z);
        }
     
    }
    

    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;
        
        rigidbody2d.MovePosition(position);
    }

    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            if (isInvincible)
                return;

            isInvincible = true;
            invincibleTimer = timeInvincible;
        }

        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
    }

    void Launch()
    {
        GameObject projectileObject = Instantiate(projectilePrefab, rigidbody2d.position + Vector2.up * 0.3f + lookDirection * .5f, Quaternion.identity);

        Projectile projectile = projectileObject.GetComponent<Projectile>();
        projectile.Launch(lookDirection, 300);

       // animator.SetTrigger("Launch");
        
    }
    void darkMatter()
    {
        GameObject projectileObject = Instantiate(bubble_Prefab, rigidbody2d.position + lookDirection * 1f, Quaternion.identity);

        dark_matter projectile = projectileObject.GetComponent<dark_matter>();
        

        animator.SetTrigger("Launch");
        
    }
    void attack()
    {
      
        animator.SetTrigger("attack");
        isattacking = true;
        attackcounter = attacktime;
       

    }
    void OpenInventory()
    {
        Inventory.enabled = true;
    }
}
[Serializable]
public class Position
{
    public float x = 76;
    public float y = -117;
    public float z = 0;

    public void Positon1(Transform transform)
    {
        GameControl.control.x = transform.position.x;
        GameControl.control.y = transform.position.y;
        GameControl.control.z = transform.position.z;
    }

    public void Positon2(Vector3 vector)
    {
        GameControl.control.x = vector.x;
        GameControl.control.y = vector.y;
        GameControl.control.z = vector.z;
    }

    public void Positon3(float posX, float posY, float posZ)
    {
        GameControl.control.x = posX;
        GameControl.control.y = posY;
        GameControl.control.z = posZ;
    }
}