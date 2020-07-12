using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enablethrow : MonoBehaviour
{
    public GameObject tr1, tr2, tr3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
