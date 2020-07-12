using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerdeadcheck : MonoBehaviour
{
    public bool dead;
    // Start is called before the first frame update
    void Start()
    {
        dead = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "bad")
        {
            Debug.Log("dead");
            dead = true;
            Destroy(gameObject);
            UImanager.dead = true;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.gameObject.tag == "enemy")
        {

            Debug.Log("dead");
            dead = true;
            Destroy(gameObject);
            UImanager.dead = true;
        }
    }


}
