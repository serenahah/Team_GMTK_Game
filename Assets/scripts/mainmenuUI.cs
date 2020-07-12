using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenuUI : MonoBehaviour
{
 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Z)){
            SceneManager.LoadScene("test");
        }
        if (Input.GetKey(KeyCode.Escape)){
            Application.Quit();
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    public void load()
    {
        SceneManager.LoadScene("test");

    }
}
