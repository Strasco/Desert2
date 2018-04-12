using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

    void Start()
    {
        Debug.Log("Quit");
    }

    public void QuitGame()
    {
        Debug.Log("Quit");

        Application.Quit();
    }
}
