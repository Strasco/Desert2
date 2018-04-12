using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public bool notFighting;
    public int deadCount;

    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject playerGirl;
    // Use this for initialization
    void Start()
    {
        notFighting = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y) && notFighting == true)
        {

            switch (PlayerPrefs.GetInt("Players"))
            {
                case 2:
                    SetupPlayer1();
                    SetupPlayer2();
                    break;
                case 3:
                    SetupPlayer1();
                    SetupPlayer2();
                    SetupPlayer3();
                    break;
                case 4:
                    SetupPlayer1();
                    SetupPlayer2();
                    SetupPlayer3();
                    SetupPlayer4();
                    break;
                default:
                    SetupPlayer1();
                    SetupPlayer2();
                    break;

            }
            AudioListener.volume = PlayerPrefs.GetFloat("AudioLevel");



            
            notFighting = false;

        }

    }
    void SetupPlayer1()
    {
        //Player 1/////////////////////////////////////////////
        Vector2 v2 = new Vector2(-8.082148f, -1.986807f);
        GameObject player1;
        if (PlayerPrefs.GetString("P1Character") == "NinjaBoy")
        {
            player1 = Instantiate(player, v2, Quaternion.identity);
            player1.GetComponent<Player>().damagePower = 30;
        }
        else
        {
            player1 = Instantiate(playerGirl, v2, Quaternion.identity);
            player1.GetComponent<Player>().damagePower = 20;
        }

        player1.transform.tag = "Player";
        Player p = player1.GetComponent<Player>();
        p.playerNumber = 1;
        p.GetComponent<SpriteRenderer>().sortingOrder = 2;
        //////////////////////////////////////////////////////////
    }
    void SetupPlayer2()
    {
        //Player 2/////////////////////////////////////////////
        GameObject player2;
        Vector2 v22 = new Vector2(8.11f, -1.986807f);
        if (PlayerPrefs.GetString("P2Character") == "NinjaBoy")
        {
            player2 = Instantiate(player, v22, Quaternion.identity);
            player2.GetComponent<Player>().damagePower = 30;
        }
        else
        {
            player2 = Instantiate(playerGirl, v22, Quaternion.identity);
            player2.GetComponent<Player>().damagePower = 20;
        }

        player2.transform.tag = "Player";
        Player p2 = player2.GetComponent<Player>();
        p2.playerNumber = 2;
        p2.GetComponent<SpriteRenderer>().sortingOrder = 3;
        //////////////////////////////////////////////////////////
    }
    void SetupPlayer3()
    {
        //Player 3/////////////////////////////////////////////
        GameObject player3;
        Vector2 v23 = new Vector2(-7.93f, 1.840428f);
        if (PlayerPrefs.GetString("P3Character") == "NinjaBoy")
        {
            player3 = Instantiate(player, v23, Quaternion.identity);
            player3.GetComponent<Player>().damagePower = 30;
        }
        else
        {
            player3 = Instantiate(playerGirl, v23, Quaternion.identity);
            player3.GetComponent<Player>().damagePower = 20;
        }
        player3.transform.tag = "Player";
        Player p3 = player3.GetComponent<Player>();
        p3.playerNumber = 3;
        p3.GetComponent<SpriteRenderer>().sortingOrder = 4;
        //////////////////////////////////////////////////////////
    }
    void SetupPlayer4()
    {
        //Player 4/////////////////////////////////////////////
        GameObject player4;
        Vector2 v24 = new Vector2(7.930913f, 1.840428f);

        if (PlayerPrefs.GetString("P3Character") == "NinjaBoy")
        {
            player4 = Instantiate(player, v24, Quaternion.identity);
            player4.GetComponent<Player>().damagePower = 30;
        }
        else
        {
            player4 = Instantiate(playerGirl, v24, Quaternion.identity);
            player4.GetComponent<Player>().damagePower = 20;
        }
        player4.transform.tag = "Player";
        Player p4 = player4.GetComponent<Player>();
        p4.playerNumber = 4;
        p4.GetComponent<SpriteRenderer>().sortingOrder = 5;
        //////////////////////////////////////////////////////////

    }

    public void Restart()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Player");
        if(deadCount == PlayerPrefs.GetInt("Players") - 1)
        {
            for (int i = 0; i < objects.Length; i++)
            {
                Destroy(objects[i], 2f);
            }
            deadCount = 0;
            notFighting = true;
        }
        

        
        
    }

}
