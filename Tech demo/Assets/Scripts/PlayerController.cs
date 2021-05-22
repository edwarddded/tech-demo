using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class PlayerController : MonoBehaviour
{
    public float JumpForce = 1f;
    public float moveSpeed = 20f;
    public float climbSpeed = 10f;
    //public bool isGrounded = false;
    private Rigidbody2D rb;
    private Animator anim;
    private GameObject fp;

    private bool IsGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;

    private float JumpTimeCounter;
    public float jumtime;
    private bool isjumping;
    public bool canMove;

    private bool isClimbing;
    private float inputHorizontal;
    private float inputVertical;
    public float distance;
    public LayerMask whatIsClimbable;

    public Animator AnimatorOfCharacter;
    public static PlayerController instance;
    public CinemachineVirtualCamera vcam;
    // Start is called before the first frame update
    void Start()
    {
        canMove = true;

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        fp = transform.Find("firePoint").gameObject;
        if (instance !=null)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        GameObject.DontDestroyOnLoad(this.gameObject);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Item")
        {
                Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "protal")
        {
            int rand = Random.Range(1, 3);
            if (rand ==1)
            {
                SceneManager.LoadScene(3);
                gameObject.transform.position = new Vector2(-26.6f, 5);
            }
            else
            {
                SceneManager.LoadScene(4);
                gameObject.transform.position = new Vector2(-60f, 10);
            }
        }
        if (collision.gameObject.tag == "forestbossPortal")
        {
            SceneManager.LoadScene(5);
            gameObject.transform.position = new Vector2(-23.8f, 28);
            
        }
       
        if (collision.gameObject.tag == "FirePortal")
        {
            int rand = Random.Range(1, 3);
            if (rand == 1)
            {
                SceneManager.LoadScene(8);
                gameObject.transform.position = new Vector2(-4.5f, 10f);
            }
            else
            {
                SceneManager.LoadScene(9);
                gameObject.transform.position = new Vector2(-1.5f, -8.3f);
            }
        }
        if (collision.gameObject.tag == "firebossProtal")
        {
            SceneManager.LoadScene(10);
            gameObject.transform.position = new Vector2(-22.4f, -11);
        }
        if (collision.gameObject.tag == "ToFire")
        {
            SceneManager.LoadScene(7);
            gameObject.transform.position = new Vector2(-25f, 12.3f);
        }
        if (collision.gameObject.tag =="ToIce")
        {
            SceneManager.LoadScene(11);
            gameObject.transform.position = new Vector2(-23.2f, 4.5f);
        }
        if (collision.gameObject.tag == "IcePortal")
        {
            int rand = Random.Range(1, 3);
            if (rand == 1)
            {
                SceneManager.LoadScene(12);
                gameObject.transform.position = new Vector2(-23.2f, 4.5f);
            }
            else
            {
                SceneManager.LoadScene(13);
                gameObject.transform.position = new Vector2(-22.8f, -9.1f);
            }
        }
        if (collision.gameObject.tag == "icebossPortal")
        {
            SceneManager.LoadScene(14);
            gameObject.transform.position = new Vector2(35.7f, 1);
        }
        if (collision.gameObject.tag == "ToFinal")
        {
            SceneManager.LoadScene(15);
            gameObject.transform.position = new Vector3(-4f, -1.11f);
        }
        if (collision.gameObject.tag == "ToFirst")
        {
            SceneManager.LoadScene(2);
            Destroyall();
        }
    }
    void Destroyall()
    {
        GameObject canvas = GameObject.Find("Canvas").gameObject;
        GameObject MC = GameObject.Find("Main Camera").gameObject;
        GameObject Cm = GameObject.Find("CM vcam1").gameObject;
        GameObject GM = GameObject.Find("GameManager").gameObject;

        if (canvas != null && MC != null && Cm != null && GM != null)
        {
            Destroy(canvas);
            Destroy(MC);
            Destroy(Cm);
            Destroy(GM);
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (!canMove) // freezing player
        {
            rb.velocity = Vector2.zero;
            AnimatorOfCharacter.SetBool("hasStopped", true);
            return;
            
        }
        else
        {
            AnimatorOfCharacter.SetBool("hasStopped", false);           
        }
       
        //Player movement
        float direction = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveSpeed * direction * Time.fixedDeltaTime, rb.velocity.y);

        AnimatorOfCharacter.SetFloat("Speed", Mathf.Abs(direction));

        if (direction != 0f)
        {
            transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x) * direction, transform.localScale.y);
           

            if (transform.localScale.x < 0.1)
                fp.transform.rotation = Quaternion.Euler(0, -180, 0);

            else
                fp.transform.rotation = Quaternion.Euler(0, 0, 0);
          
        }

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.up, distance, whatIsClimbable);

        if(hitInfo.collider != null)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                isClimbing = true;
            } else {
                if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
                {
                    isClimbing = false;
                }
            }
        }

        if(isClimbing == true && hitInfo.collider != null)
        {
            inputVertical = Input.GetAxisRaw("Vertical");
            rb.velocity = new Vector2(rb.velocity.x, inputVertical * climbSpeed);
            rb.gravityScale = 0;
            AnimatorOfCharacter.SetBool("isClimbing", true);
        }
        else
        {
            rb.gravityScale = 5;
            AnimatorOfCharacter.SetBool("isClimbing", false);
        }

        
    }

    void Update()
    {
        //Player Jump
        IsGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
        if (IsGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            isjumping = true;
            JumpTimeCounter = jumtime;
            rb.velocity = Vector2.up * JumpForce;
        }
        if (Input.GetKey(KeyCode.Space) && isjumping == true)
        {
            if (JumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * JumpForce;
                JumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isjumping = false;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isjumping = false;
        }

        if (SceneManager.GetActiveScene().name == "Boss1")
        {
            vcam.m_Lens.OrthographicSize = 28f;
        }
        else
        {
            vcam.m_Lens.OrthographicSize = 10f;
        }

    }
}
