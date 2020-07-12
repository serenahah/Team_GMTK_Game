using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movPlatform : MonoBehaviour
{
    public Transform positionA; // the target position
    public Transform positionB;
    public float speed; // speed - units per second (gives you control of how fast the object will move in the inspector)
    public bool moveObj; // a public bool that allows you to toggle this script on and off in the inspector
    bool positionAbool, positionBbool;
    private void Start()
    {
        positionAbool = true;
        positionBbool = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (positionAbool)
        {
            if (moveObj == true)
            {
                float step = speed * Time.deltaTime; // step size = speed * frame time
                transform.position = Vector3.MoveTowards(transform.position, positionB.position, step); // moves position a step closer to the target position
                if (transform.position == positionB.position)
                {
                    positionBbool = true;
                    positionAbool = false;
                }
            }
        }
        if (positionBbool)
        {
            if (moveObj == true)
            {
                float step = speed * Time.deltaTime; // step size = speed * frame time
                transform.position = Vector3.MoveTowards(transform.position, positionA.position, step); // moves position a step closer to the target position
                if (transform.position == positionA.position)
                {
                    positionAbool = true;
                    positionBbool = false;
                }
            }
        }

    }
}
