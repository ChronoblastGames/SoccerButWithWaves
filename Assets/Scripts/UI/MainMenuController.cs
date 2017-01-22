using System.Collections;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    [Header("Selection Attributes")]
    public int totalNumberOfPlayers;
    private int playerNumber;

    public Material redColor;
    public Material blueColor;
    public Material greenColor;

    public GameObject[] defaultArrayPosition;

    [Header("Red Team Attributes")]
    public int numberOfPlayersOnRedTeam;

    public GameObject[] redTeamArrayPosition;

    public bool[] isRedTeamSpotTaken;

    [Header("Blue Team Attributes")]
    public int numberOfPlayersOnBlueTeam;

    public GameObject[] blueTeamArrayPosition;

    public bool[] isBlueTeamSpotTaken;

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
                if (!isBlueTeamSpotTaken[playerNumber])
                {
                    isBlueTeamSpotTaken[playerNumber] = true;
                    player.GetComponent<Renderer>().material = blueColor;
                    player.transform.position = blueTeamArrayPosition[playerNumber].transform.position;
                    numberOfPlayersOnBlueTeam++;
                    totalNumberOfPlayers++;
                    return;
                }
                else if (isRedTeamSpotTaken[playerNumber])
                {
                    Debug.Log("Blargh");
                    return;
                }
                break;

            case "Right":
                if (!isRedTeamSpotTaken[playerNumber])
                {
                    isRedTeamSpotTaken[playerNumber] = true;
                    player.GetComponent<Renderer>().material = redColor;
                    player.transform.position = redTeamArrayPosition[playerNumber].transform.position;
                    numberOfPlayersOnRedTeam++;
                    totalNumberOfPlayers++;
                    return;
                }
                else if (isBlueTeamSpotTaken[playerNumber])
                {
                    Debug.Log("Blargh");
                    return;
                }
                break;

            default:
                Debug.Log("Something Incorrect passed through the direction indentification, Was: " + direction);
                break;
        }

    }

    public void StartGame()
    {

    }
}
