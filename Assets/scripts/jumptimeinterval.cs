using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumptimeinterval : MonoBehaviour
{
    private float timeinterval;
    Rigidbody2D rb;
    int num;
    Animator ani;
    public float jumptime;
    bool midjump;
    // Start is called before the first frame update
    void Start()
    {
        timeinterval = 10;
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(jumpWave());
        num = 1;
        ani = GetComponent<Animator>();
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
            ani.SetBool("jump", true);
            StartCoroutine(jumpinmotion());
            midjump = true;
            if ( num == 1)
            {
                timeinterval = 5;
                num = 2;
            }
            if (num == 2)
            {
                timeinterval = 10;
                num = 1;
            }

        }
    }
    IEnumerator jumpinmotion()
    {
        while (true)
        {
            yield return new WaitForSeconds(jumptime);
            ani.SetBool("jump", false);
            midjump = false;
            StopCoroutine(jumpinmotion());
        }
    }


}
