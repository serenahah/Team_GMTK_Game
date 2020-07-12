using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handanimation : MonoBehaviour
{
    public static bool trigger;
    Animator ani;
    // Start is called before the first frame update
    void Start()
    {
        trigger = false;
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (trigger == true)
        {
            ani.SetBool("up", true);
            trigger = false;
        }
        
    }
}
