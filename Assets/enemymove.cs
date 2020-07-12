using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemymove : MonoBehaviour
{
    Rigidbody2D rb;
    public float moveby;
    public AudioSource sythe;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void move()
    {
        rb.velocity = new Vector2(moveby, rb.velocity.y);
    }
    private void playsythe()
    {
        sythe.Play();
    }
}
