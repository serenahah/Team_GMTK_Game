using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthsystem : MonoBehaviour
{
    public GameObject fullhealth;
    public GameObject hit1;
    public GameObject hit2;
    public GameObject hit3;
    public GameObject hit4;
    public GameObject empty;
    float hit;
    // Start is called before the first frame update
    void Start()
    {
        fullhealth.SetActive(true);
        hit1.SetActive(false);
        hit2.SetActive(false);
        hit3.SetActive(false);
        hit4.SetActive(false);
        empty.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        hitcheck();
        
    }
    public  void hitcheck()
    {
        hit = playerdeadcheck.hit;
        if (hit == 1)
        {
            fullhealth.SetActive(false);
            hit1.SetActive(true);
        }
        if (hit == 2)
        {
            hit1.SetActive(false);
            hit2.SetActive(true);
        }
        if (hit == 3)
        {
            hit2.SetActive(false);
            hit3.SetActive(true);
        }
        if (hit == 4)
        {
            hit3.SetActive(false);
            hit4.SetActive(true);
        }
        if (hit == 5)
        {
            hit4.SetActive(false);
            empty.SetActive(true);
        }
    }
}
