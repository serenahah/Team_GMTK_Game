using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
     public Transform player;

     public GameObject player_tile;
 
     // Start is called before the first frame update
     void Start()
     {
 
     }
 
     // Update is called once per frame
     void Update()
     {
         if (Input.GetButtonDown("Fire1"))
         {
            shootBullet();

         }
    }

    public void shootBullet(){
        GameObject b = Instantiate(player_tile) as GameObject;
        b.transform.position = player.transform.position;
        var currentPos = b.transform.position;
        b.transform.position = new Vector3(Mathf.Round(currentPos.x *2f)*0.5f,
                             Mathf.Round(currentPos.y*2f)*0.5f,
                             Mathf.Round(currentPos.z*2f)*0.5f);
    }
}
