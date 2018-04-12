using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class UINavigation : MonoBehaviour
{


    [SerializeField]
    private GameObject KunaiSelection;
    public GameObject firstButton;

    void Start()
    {
        
        EventSystem.current.firstSelectedGameObject = firstButton;
        EventSystem.current.SetSelectedGameObject(firstButton);
        
        
    }

    
    public void PlayGame()
    {
       
        SceneManager.LoadScene("BattleArenaScene");
    }

    public void QuitGame()
    {
        Debug.Log("QuitGame");
         Application.Quit();
    }




}

