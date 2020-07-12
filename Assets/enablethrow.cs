using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enablethrow : MonoBehaviour
{
    public GameObject tr1, tr2, tr3;
    public LayerMask lay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 currentpos = new Vector2(transform.position.x, transform.position.y);
        Vector2 to = new Vector2(10, 0);

        Debug.DrawRay(currentpos, to, Color.green);
        
        RaycastHit2D hitRight = Physics2D.Raycast(currentpos, to, 10, lay);
        if (hitRight)
        {
            Debug.Log("hit");
        }
    }
     
    void throwright1()
    {
        tr1.SetActive(true);

    }
    void throwright2()
    {
        tr2.SetActive(true);
    }
    void throwright3()
    {
        tr3.SetActive(true);
      

    }


    private void Oisableall()
    {
        tr1.SetActive(false);
        tr2.SetActive(false);
        tr3.SetActive(false);

    }
}
