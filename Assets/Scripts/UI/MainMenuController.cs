using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public static MainMenuController mainMenuController;

    [Header("Selection Attributes")]

    [SerializeField]
    public List <int> playerOrderList;
    private int playerNumber;

    public Material redColor;
    public Material blueColor;
    public Material greenColor;

    public GameObject[] defaultArrayPosition;

    [Header("Red Team Attributes")]
    public GameObject[] redTeamArrayPosition;

    public bool[] isRedTeamSpotTaken;

    [SerializeField]
    public List<int> redTeamList;

    [Header("Blue Team Attributes")]
    public GameObject[] blueTeamArrayPosition;

    public bool[] isBlueTeamSpotTaken;

    [SerializeField]
    public List<int> blueTeamList;

    void Start()
    {
        InstanceManagement();
    }

    void InstanceManagement()
    {
        if (mainMenuController != null && mainMenuController)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            mainMenuController = this;
        }

        DontDestroyOnLoad(gameObject);
    }

    public void MovePlayerToPosition(string direction, GameObject player, string playerTag)
    {
        switch(playerTag)
        {
            case "Player1":
                playerNumber = 0;
                break;

            case "Player2":
                playerNumber = 1;
                break;

            case "Player3":
                playerNumber = 2;
                break;

            case "Player4":
                playerNumber = 3;
                break;

            default:
                Debug.Log("Something incorrect passed through Player Number Indentification! Was: " + playerTag);
                break;
        }

        switch (direction)
        {
            case "Left":
                if (isRedTeamSpotTaken[playerNumber])
                {
                    PlaceOnTeam("Middle", player, playerNumber);
                    return;
                }
                else if (!isBlueTeamSpotTaken[playerNumber])
                {
                    PlaceOnTeam("Blue", player, playerNumber);
                    return;
                }
                else if (isRedTeamSpotTaken[playerNumber])
                {
                    PlaceOnTeam("Middle", player, playerNumber);
                    return;
                }
                break;

            case "Right":
                if (isBlueTeamSpotTaken[playerNumber])
                {
                    PlaceOnTeam("Middle", player, playerNumber);
                    return;
                }
                else if (!isRedTeamSpotTaken[playerNumber])
                {
                    PlaceOnTeam("Red", player, playerNumber);
                    return;
                }
                else if (isBlueTeamSpotTaken[playerNumber])
                {
                    PlaceOnTeam("Middle", player, playerNumber);
                    return;
                }
                break;

            default:
                Debug.Log("Something Incorrect passed through the direction indentification, Was: " + direction);
                break;
        }

    }

    void PlaceOnTeam(string teamColor, GameObject player, int playerNumber)
    {
        switch (teamColor)
        {
            case "Red":
                player.transform.position = redTeamArrayPosition[playerNumber].transform.position;
                player.GetComponent<Renderer>().material.color = redColor.color;
                isRedTeamSpotTaken[playerNumber] = true;
                isBlueTeamSpotTaken[playerNumber] = false;
                redTeamList.Add(playerNumber);
                playerOrderList.Add(playerNumber);
                playerOrderList.Sort();
                break;

            case "Blue":
                player.transform.position = blueTeamArrayPosition[playerNumber].transform.position;
                player.GetComponent<Renderer>().material.color = blueColor.color;
                isBlueTeamSpotTaken[playerNumber] = true;
                isRedTeamSpotTaken[playerNumber] = false;
                blueTeamList.Add(playerNumber);
                playerOrderList.Add(playerNumber);
                playerOrderList.Sort();
                break;

            case "Middle":
                player.transform.position = defaultArrayPosition[playerNumber].transform.position;
                player.GetComponent<Renderer>().material.color = greenColor.color;
                isRedTeamSpotTaken[playerNumber] = false;
                isBlueTeamSpotTaken[playerNumber] = false;
                redTeamList.Remove(playerNumber);
                blueTeamList.Remove(playerNumber);
                playerOrderList.Remove(playerNumber);
                break;

            default:
                Debug.Log("Wrong argument passed through Team Adder, was: " + teamColor);
                break;
        }
    }
    public void StartGame()
    {
        if (redTeamList.Count > 0 && blueTeamList.Count > 0)
        {
            LevelManager.LoadLevel(01);         
        }
    }
}
