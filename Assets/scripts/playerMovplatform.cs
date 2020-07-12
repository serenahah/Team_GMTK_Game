using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovplatform : MonoBehaviour
{
    private Transform m_currMovingPlatform;


    void OnCollisionEnter2D(Collision2D other)
    {


        if (other.gameObject.tag == "moving")
        {
            m_currMovingPlatform = other.gameObject.transform;
            transform.SetParent(m_currMovingPlatform);
        }


    }
    private void OnCollisionExit2D(Collision2D other)
    {

        if (other.gameObject.tag == "moving")
        {
            transform.parent = null;
            m_currMovingPlatform = null;

        }

    }
}
