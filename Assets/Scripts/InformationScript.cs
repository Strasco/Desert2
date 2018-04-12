using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InformationScript : MonoBehaviour {

    public float masterAudioSettings = 1;
    public string map;
    public int numberOfCharacters;
    public string p1_character;
    public string p2_character;
    public string p3_character;
    public string p4_character;

    public InformationScript()
    {

    }

    public void StartGame()
    {
        Debug.Log("Map Will start with:" + masterAudioSettings + " Audio volume" + map + " map" + numberOfCharacters);
        if (map == "DesertBG")
            SceneManager.LoadScene("BattleArenaScene");

     }




}
