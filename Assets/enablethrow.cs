using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enablethrow : MonoBehaviour
{
    public LayerMask lay;
    bool direction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        if (x>0.5)
        {
            direction = true;
        }
        else if(x<-0.5)
        {
            direction = false;
        }
        Debug.Log("direction"+direction);
    }

    void throwright3()
    {
        if (direction)
        {
            Vector2 currentpos = new Vector2(transform.position.x, transform.position.y);
            Vector2 to = new Vector2(10, 0);

            Debug.DrawRay(currentpos, to, Color.green);

            RaycastHit2D hitRight = Physics2D.Raycast(currentpos, to, 10, lay);
            if (hitRight)
            {
                Debug.Log("hit");
                Destroy(hitRight.transform.gameObject);
            }
        }
        else
        {
            Vector2 currentpos = new Vector2(transform.position.x, transform.position.y);
            Vector2 to = new Vector2(-10, 0);

            Debug.DrawRay(currentpos, to, Color.green);

            RaycastHit2D hitRight = Physics2D.Raycast(currentpos, to, 10, lay);
            if (hitRight)
            {
                Debug.Log("hit");
                Destroy(hitRight.transform.gameObject);
            }
        }
       
            
        


    }

}
