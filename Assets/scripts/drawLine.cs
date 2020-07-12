using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawLine : MonoBehaviour
{

    public GameObject Linegeneratorprefab;

    public GameObject hand;
    public GameObject hand2;
    public GameObject player;
    public GameObject hand3;
    public GameObject hand4;

    GameObject newlinegen;
    LineRenderer lrend;
    GameObject newlinegen2;
    LineRenderer lrend2;
    GameObject newlinegen3;
    LineRenderer lrend3;
    GameObject newlinegen4;
    LineRenderer lrend4;
    public void Start()
    {

        newlinegen = Instantiate(Linegeneratorprefab) as GameObject;
        lrend = newlinegen.GetComponent<LineRenderer>();
        newlinegen2 = Instantiate(Linegeneratorprefab) as GameObject;
        lrend2 = newlinegen2.GetComponent<LineRenderer>();
        newlinegen3 = Instantiate(Linegeneratorprefab) as GameObject;
        lrend3 = newlinegen3.GetComponent<LineRenderer>();
        newlinegen4 = Instantiate(Linegeneratorprefab) as GameObject;
        lrend4 = newlinegen4.GetComponent<LineRenderer>();
    }
    public void Update()
    {

        lrend.SetPosition(0, new Vector3(hand.transform.position.x, hand.transform.position.y, 0));
        lrend.SetPosition(1, new Vector3(player.transform.position.x, player.transform.position.y, 0));
        lrend2.SetPosition(0, new Vector3(hand2.transform.position.x, hand2.transform.position.y, 0));
        lrend2.SetPosition(1, new Vector3(player.transform.position.x, player.transform.position.y, 0));
        lrend3.SetPosition(0, new Vector3(hand3.transform.position.x, hand3.transform.position.y, 0));
        lrend3.SetPosition(1, new Vector3(player.transform.position.x, player.transform.position.y, 0));
        lrend4.SetPosition(0, new Vector3(hand4.transform.position.x, hand4.transform.position.y, 0));
        lrend4.SetPosition(1, new Vector3(player.transform.position.x, player.transform.position.y, 0));
    }
    private void spawnLinegenerator()
    {

        
    }
}
