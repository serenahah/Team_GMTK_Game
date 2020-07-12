using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumptimeinterval : MonoBehaviour
{
    public float timeinterval, jumpforce;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(jumpWave());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator jumpWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeinterval);
            rb.velocity = new Vector2(rb.velocity.x, jumpforce);
            handanimation.trigger = true;
        }
    }


}
