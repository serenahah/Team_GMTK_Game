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
    GameObject[] pause;
    GameObject[] bg;
    GameObject[] pp;
    GameObject[] health;
    bool gameon, pauseon, gameoveron;
    // Start is called before the first frame update
    void Start()
    {
        gameover = GameObject.FindGameObjectsWithTag("ondead");
        pause = GameObject.FindGameObjectsWithTag("onpause");
        bg = GameObject.FindGameObjectsWithTag("bg");
        pp = GameObject.FindGameObjectsWithTag("pp");
        health = GameObject.FindGameObjectsWithTag("health");
        hidegameover();
        dead = false;
        hidebg();
        hidepaused();
        gameoveron = false;
        pauseon = false;
        gameon = true;
        Time.timeScale = 1;
    }

    void Update()
    {
        if (dead == true)
        {
            gameoveron = true;
            gameon = false;
            showgameover();
            showbg();
            hidepp();
            hidehealth();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("menu");
            }
            if (Input.GetKeyDown(KeyCode.Z))
            {
                SceneManager.LoadScene("gameplay");
            }

        }
        if( gameon == true && Input.GetKey(KeyCode.Escape))
        {
            pauseon = true;
            gameon = false;
            showpaused();
            showbg();
            hidepp();
            hidehealth();
            Time.timeScale = 0;
        }
        if(pauseon == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("menu");
            }
            else if (Input.GetKey(KeyCode.Z))
            {
                pauseon = false;
                gameon = true;
                hidepaused();
                hidebg();
                showpp();
                showhealth();
                Time.timeScale = 1;
            }

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

    void showpaused()
    {
        foreach (GameObject g in pause)
        {
            g.SetActive(true);
        }
    }
    void hidepaused()
    {
        foreach (GameObject g in pause)
        {
            g.SetActive(false);
        }
    }
    void showbg()
    {
        foreach (GameObject g in bg)
        {
            g.SetActive(true);
        }
    }
    void hidebg()
    {
        foreach (GameObject g in bg)
        {
            g.SetActive(false);
        }
    }
    void showpp()
    {
        foreach (GameObject g in pp)
        {
            g.SetActive(true);
        }
    }
    void hidepp()
    {
        foreach (GameObject g in pp)
        {
            g.SetActive(false);
        }
    }
    void showhealth()
    {
        foreach (GameObject g in health)
        {
            g.SetActive(true);
        }
    }
    void hidehealth()
    {
        foreach (GameObject g in health)
        {
            g.SetActive(false);
        }
    }
    public void reload()
    {
        SceneManager.LoadScene("test");

    }
}
