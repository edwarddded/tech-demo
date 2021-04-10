using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float JumpForce = 1f;
    public float moveSpeed = 20f;
    //public bool isGrounded = false;
    private Rigidbody2D rb;
    private Animator anim;

    private bool IsGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;

    private float JumpTimeCounter;
    public float jumtime;
    private bool isjumping;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Item")
        {
                Destroy(collision.gameObject);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //movement
        float direction = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveSpeed * direction * Time.fixedDeltaTime, rb.velocity.y);
        if (direction != 0f)
        {
            transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x) * direction, transform.localScale.y);
        }

        //if (Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.001f)
        //{
        //    rb.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        //}
    }
    void Update()
    {
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

    }
}
