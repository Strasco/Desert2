using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberOfPlayers : MonoBehaviour {

    public InformationScript info;
    public int playerNumber;
    private Text text;
    public bool locked;
    [SerializeField]
    private Button PlayButton;
    [SerializeField]
    private GameObject _P1, _P2, _P3, _P4;
    [SerializeField]
    private Sprite[] characters;
    
	// Use this for initialization
	void Start () {
        locked = false;
        text = GetComponent<Text>();
        playerNumber = 2;
        text.text = "Number of players: " + playerNumber;
        PlayButton.interactable = false;

        
        
	}
	
	// Update is called once per frame
	void Update () {

        P1Control();
        P2Control();
        CharacterNumberControl();
            
        

        if (Input.GetButtonDown("Submit"))
        {
            locked = true;
            text.text = "Number of players: " + playerNumber  + " Locked";
            PlayButton.interactable = true;
        }

    }

    void CharacterNumberControl()
    {
        switch (playerNumber)
        {
            case 2:
                _P3.SetActive(false);
                _P4.SetActive(false);
                break;
            case 3:
                _P3.SetActive(true);
                _P4.SetActive(false);
                break;
            case 4:
                _P3.SetActive(true);
                _P4.SetActive(true);
                break;
            default:
                break;

        }
    }
        void P1Control()
    {
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.Joystick1Button15))
        {
            if (locked == false)
            {
                if (playerNumber < 4)
                {
                    playerNumber++;
                    text.text = "Number of players: " + playerNumber;
                }
            }
            else
            {
                _P1.GetComponent<Image>().sprite = characters[1];
            }



        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.Joystick1Button14))
        {
            if (locked == false)
            {
                if (playerNumber > 2)
                {
                    playerNumber--;
                    text.text = "Number of players: " + playerNumber;
                }
            }
            else
            {
                _P1.GetComponent<Image>().sprite = characters[0];
            }

        }
    }
    void P2Control()
    {
        if(locked == true)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                _P2.GetComponent<Image>().sprite = characters[1];
            }else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                _P2.GetComponent<Image>().sprite = characters[0];
            }

        }
    }
    public void StartGame()
    {
        info.numberOfCharacters = playerNumber;
        if(_P1.GetComponent<Image>().sprite == characters[0])
            info.p1_character = "NinjaBoy";
        else
            info.p1_character = "NinjaGirl";

        PlayerPrefs.SetString("P1Character", info.p1_character);

        if (_P2.GetComponent<Image>().sprite == characters[0])
            info.p2_character = "NinjaBoy";
        else
            info.p2_character = "NinjaGirl";

        PlayerPrefs.SetString("P2Character", info.p2_character);

        if ((_P3.GetComponent<Image>().sprite == characters[0]) && _P3.activeSelf)
            info.p3_character = "NinjaBoy";
        else
            info.p3_character = "NinjaGirl";

        PlayerPrefs.SetString("P3Character", info.p3_character);

        if ((_P4.GetComponent<Image>().sprite == characters[0]) && _P4.activeSelf)
            info.p4_character = "NinjaBoy";
        else
            info.p4_character = "NinjaGirl";

        PlayerPrefs.SetString("P4Character", info.p4_character);
        PlayerPrefs.SetInt("Players", playerNumber);
        info.StartGame();

    }
}
