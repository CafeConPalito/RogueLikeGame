using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    public static void play()
    {
        SceneManager.LoadScene("Selector");
    }

    public static void settings()
    {
        
    }

    public static void exit()
    {
        Application.Quit();
    }
}
