using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UImanager : MonoBehaviour
{


    public static bool dead;
    public float x, y;
    public GameObject player;
    GameObject[] gameover;
    // Start is called before the first frame update
    void Start()
    {
        gameover = GameObject.FindGameObjectsWithTag("ondead");
        hidegameover();
        dead = false;
    }

    void Update()
    {
        if (dead == true)
        {
            showgameover();
        }


    }
    void showgameover()
    {
        foreach (GameObject g in gameover)
        {
            g.SetActive(true);
        }
    }
    void hidegameover()
    {
        foreach (GameObject g in gameover)
        {
            g.SetActive(false);
        }
    }

    public void reload()
    {
        SceneManager.LoadScene("test");

    }
}
