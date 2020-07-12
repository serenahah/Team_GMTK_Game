using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemymove : MonoBehaviour
{
    Rigidbody2D rb, player;
    public float moveby;
    public AudioSource sythe;
    GameObject pl;
    float playerpos, enpos;
    float beh;
    public Transform positionA; // the target position
    public Transform positionB;
    bool positionAbool, positionBbool;
    Animator ani;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pl = GameObject.FindWithTag("Player");
        ani = GetComponent<Animator>();
        player = pl.GetComponent<Rigidbody2D>();
        beh = 0;
        positionAbool = true;
        positionBbool = false;
        ani.SetBool("direction", true);
    }

    // Update is called once per frame
    void Update()
    {
        playerpos = player.transform.position.x;
        enpos = rb.transform.position.x;
        float dis = Mathf.Abs(playerpos - enpos);
        if (dis > 4)
        {
            beh = 1; Behaviour1();
        }
        else if (dis <= 4)
        {
            beh = 2;
            Behaviour1();
        }

    }

    void Behaviour1()
    {
        if (positionAbool)
        {


            ani.SetBool("direction", true);
                if (transform.position.x >= positionB.position.x)
                {
                    positionBbool = true;
                    positionAbool = false;
                }
            
        }
        if (positionBbool)
        {
            ani.SetBool("direction", false);
            if (transform.position.x <= positionA.position.x)
                {
                    positionAbool = true;
                    positionBbool = false;
                }
            
        }

    }
    public void move()
    { 
        rb.velocity = new Vector2(moveby, rb.velocity.y);
    }
    public void moveleft()
    {
        rb.velocity = new Vector2(-moveby, rb.velocity.y);
    }
    public void playsythe()
    {
        sythe.Play();
    }
}
