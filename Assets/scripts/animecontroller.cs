using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animecontroller : MonoBehaviour
{
    Rigidbody2D rb;
    Animator ani;
    bool midair, midjump;
    public float jumptime, throwtime;
    bool hidestate, throwstate;

    private SpriteRenderer spriteren;
    public AudioSource jump;
    public AudioSource thro;
    private void Awake()
    {
        spriteren = GetComponent<SpriteRenderer>();

    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        midair = false;
        midjump = false;
        hidestate = false;
        throwstate = false;
    }

    private void FixedUpdate()
    {
        if(hidestate == false && throwstate == false)
        {
            Move();
        }
        
    }
    // Update is called once per frame
    void Update()
    {

        
        float x = Input.GetAxisRaw("Horizontal");
        Debug.Log(x);
        if (hidestate == false && throwstate == false)
        {
            bool flipsorite = (spriteren.flipX ? (x > 0.01f) : (x < -0.01f));
            if (flipsorite)
            {
                spriteren.flipX = !spriteren.flipX;
            }
        }
        if (x == 0)
        {
            ani.SetBool("idle", true);
            ani.SetBool("moving", false);
        }
        if (x != 0)
        {
            ani.SetBool("moving", true);
            ani.SetBool("idle", false);
        }

        if (Input.GetKeyDown(KeyCode.Z) && midjump == false && hidestate == false && throwstate == false)
        {
            ani.SetBool("jump", true);
            midair = true;
            midjump = true;
            StartCoroutine(jumpinmotion());
        }
        /*


            else if (rb.velocity.y < 0 )
            {
                ani.SetBool("midair", true);

            }
            else if (rb.velocity.y == 0 && midair == true)
            {
                       ani.SetBool("jump", false);
                       ani.SetBool("midair", false);
                       ani.SetBool("land", true);
                       midair = false;
            }
            */


        if (Input.GetKey(KeyCode.C) && midjump == false && throwstate == false)
        {
            ani.SetBool("hide", true);
            hidestate = true;
        }
        else
        {
            ani.SetBool("hide", false);
            hidestate = false;
        }

        if (Input.GetKeyDown(KeyCode.X) && midjump == false && hidestate == false)
        {
            ani.SetBool("throw", true);
            throwstate = true;
            StartCoroutine(throwinmotion());
        }
    }

    void Move()
    {

        float x = Input.GetAxisRaw("Horizontal");

        float moveBy = x * 5;

        rb.velocity = new Vector2(moveBy, rb.velocity.y);
    }
    IEnumerator jumpinmotion()
    {
        while (true)
        {
            yield return new WaitForSeconds(jumptime);
            ani.SetBool("jump", false);
            midjump = false;
            StopAllCoroutines();
        }
    }
    IEnumerator throwinmotion()
    {
        while (true)
        {
            yield return new WaitForSeconds(throwtime);
            ani.SetBool("throw", false);
            throwstate = false;
            StopAllCoroutines();
        }
    }
    void Jumpsound()
    {
        jump.Play();

    }
    void throwsound()
    {
        thro.Play();
    }
}
