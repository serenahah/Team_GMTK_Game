using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerdeadcheck : MonoBehaviour
{
    public bool dead;
    public float hitfreezetime;
    public static int hit;
    bool hitpause, wcon;
    // Start is called before the first frame update
    void Start()
    {
        dead = false;
        hit = 0;
        hitpause = false;
        wcon = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*
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
    */
    void OnCollisionStay2D(Collision2D collision)
    {

        Debug.Log("in col stay" + hitpause);
        if (collision.gameObject.tag == "enemy" && hitpause == false)
        {
            hit++;
            Debug.Log(hit);
            if(hit == 5)
            {
                UImanager.dead = true;
            }
            shakecine.shake = true;
            StartCoroutine(hitfreeze());
            hitpause = true;

        }
    }
    IEnumerator hitfreeze()
    {

        while (true)
        {

            
            
            yield return new WaitForSeconds(hitfreezetime);
            hitpause = false;            
            StopCoroutine(hitfreeze());

        }
    }

}
