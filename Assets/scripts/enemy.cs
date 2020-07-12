using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{

    float start_pos;
    float end_pos;
    public float units_mov;
    Rigidbody2D rb;
    bool direction;
    public float velocity;
    bool flipped;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        start_pos = transform.position.x;
        end_pos = start_pos - units_mov;
        direction = false;
        flipped = false;
    }

    // Update is called once per frame
    void Update()
    { 
        if (flipped == false)
        {
            move();
        }



    }
    void move()
    {
        float currentpos = transform.position.x;
        if (currentpos >= start_pos)
        {
            direction = false;
        }
        else if (currentpos <= end_pos)
        {
            direction = true;
        }

        if (direction)
        {
            rb.velocity = new Vector2(velocity, rb.velocity.y);
        }
        else
            rb.velocity = new Vector2(-velocity, rb.velocity.y);


    }
}
