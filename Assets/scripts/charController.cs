using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charController : MonoBehaviour
{
    private Rigidbody2D rb;

    [Header("Movement Settings")]
    public float Speed = 0;
    public float MaxSpeed = 10;
    public float Acceleration = 10;
    public float Deceleration = 10;
    public float position;
    float speed;

    [Header("Jump Settings")]
    public float jumpForce;
    public int defaultJumps = 1;
    int morejumps;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    bool firstjump;


    [Header("Grounded checker")]
    public float checkGroundRadius;
    public Transform isGroundedChecker;
    public LayerMask groundLayer;
    public float rememberGroundedFor;
    float lastTimeGrounded;
    bool isGrounded = false;
    bool onlyonce;

    [Header("Disable keys")]
    public bool disableleft;
    public bool disableRight;
    public bool disableJump;


    Animator ani;
    float timetojump;

 
    void Start()
    {
        morejumps = defaultJumps;
        rb = GetComponent<Rigidbody2D>();
        morejumps = defaultJumps;
        onlyonce = true;
        firstjump = false;
        disableJump = false;
        disableleft = false;
        disableRight = false;
        ani = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
       // Move();
    }
    // Update is called once per frame
    void Update()
    {
        CheckIfGrounded();
       // Jump();
        BetterJump();
    }
    void Move()
    {

        /*if ((Input.GetKey("left")) && (Speed > -MaxSpeed) && disableleft == false)
        {
            Speed = Speed - Acceleration * Time.deltaTime;
            if (Speed > 0)
            {
                Speed = Speed - Deceleration * Time.deltaTime;
            }
        }
        else if ((Input.GetKey("right")) && (Speed < MaxSpeed) && disableRight == false)
        {
            Speed = Speed + Acceleration * Time.deltaTime;
            if (Speed < 0)
            {
                Speed = Speed + Deceleration * Time.deltaTime;
            }
        }

        else
        {
            if (Speed > Deceleration * Time.deltaTime) Speed = Speed - Deceleration * Time.deltaTime;
            else if (Speed < -Deceleration * Time.deltaTime) Speed = Speed + Deceleration * Time.deltaTime;
            else
                Speed = 0;
        }
        position = transform.position.x + Speed * Time.deltaTime;
        transform.position = new Vector2(position, transform.position.y);*/
        
        float x = Input.GetAxisRaw("Horizontal");

        float moveBy = x * 5;

        rb.velocity = new Vector2(moveBy, rb.velocity.y);
    }

    void Jump()
    {

        if (Input.GetKeyDown(KeyCode.Space) && (isGrounded) && disableJump == false)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

            transform.parent = null;
            firstjump = true;

        }
        if (Input.GetKeyDown(KeyCode.Space) && morejumps > 0 && firstjump == true && disableJump == false)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            morejumps--;

            transform.parent = null;
        }



    }

    void jmp()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    void CheckIfGrounded()
    {
        Collider2D colliders = Physics2D.OverlapCircle(isGroundedChecker.position, checkGroundRadius, groundLayer);

        if (colliders != null)
        {
            isGrounded = true;

            morejumps = defaultJumps;
            firstjump = false;

            if (onlyonce)
            {
                onlyonce = false;
                morejumps = defaultJumps;
            }
        }
        else
        {
            if (isGrounded)
            {
                lastTimeGrounded = Time.time;
            }
            isGrounded = false;
            onlyonce = true;
        }


    }




    void BetterJump()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rb.velocity += Vector2.up * Physics2D.gravity * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }



}
