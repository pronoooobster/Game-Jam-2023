using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class change : MonoBehaviour
{
    // change scene to the menu
    public void ChangeToMenu()
    {
        GameObject.Find("Canvas").SetActive(true);
        // use scene manager
        SceneManager.LoadScene("Menu");
        // enable the canvas element
    }

    // change to main
    public void ChangeToMain()
    {
        SceneManager.LoadScene("Main");
        // disable the canvas element
        GameObject.Find("Canvas").SetActive(false);
    }

}
