using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RetryButton();
        ExitButton();
    }

    public void RetryButton()
    {
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene("Hide and Seek Room");
        }
    }

    public void ExitButton()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
