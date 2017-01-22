using System.Collections;
using UnityEngine;

public class GameInit : MonoBehaviour
{
    private MainMenuController mainMenuController;

    private GameObject playerHolder;

    [Header("Map Setup Attributes")]
    private int numberOfPlayers;
    private int numberOfPlayersOnRed;
    private int numberOfPlayersOnBlue;

    public GameObject[] redTeamSpawns;
    public GameObject[] blueTeamSpawns;

    public GameObject[] playerList;

    [Header("Player Colors")]
    public Material[] redColors;

    public Material[] blueColors;

    void Start()
    {
        Setup();
    }

    void Setup()
    {
        mainMenuController = GameObject.FindGameObjectWithTag("GameController").GetComponent<MainMenuController>();

        playerHolder = GameObject.FindGameObjectWithTag("PlayerHolder");

        int numberOfRedPlayers = mainMenuController.redTeamList.Count;
        int numberOfBluePlayers = mainMenuController.blueTeamList.Count;
        numberOfPlayers = numberOfRedPlayers + numberOfBluePlayers;

        Debug.Log(numberOfPlayers);

        SpawnPlayers();
    }

    void SpawnPlayers()
    {
        for (int i = 0; i < numberOfPlayers; i++)
        {
            if (mainMenuController.redTeamList.Contains(i))
            {
                InitiatePlayer(i, "Red");
                continue;
            }
            else if (mainMenuController.blueTeamList.Contains(i))
            {
                InitiatePlayer(i, "Blue");
                continue;
            }
        }
    }

    void InitiatePlayer(int playerNumber, string teamColor)
    {
        switch (teamColor)
        {
            case "Red":
                GameObject newRedPlayer = Instantiate(playerList[playerNumber], redTeamSpawns[playerNumber].transform.position, redTeamSpawns[playerNumber].transform.rotation, redTeamSpawns[playerNumber].transform);
                newRedPlayer.GetComponent<Renderer>().material = redColors[numberOfPlayersOnRed];
                Debug.Log("Spawned player " + playerNumber + "on " + teamColor);
                numberOfPlayersOnRed++;
                break;

            case "Blue":
                GameObject newBluePlayer = Instantiate(playerList[playerNumber], blueTeamSpawns[playerNumber].transform.position, blueTeamSpawns[playerNumber].transform.rotation, blueTeamSpawns[playerNumber].transform);
                newBluePlayer.GetComponent<Renderer>().material = blueColors[numberOfPlayersOnBlue];
                Debug.Log("Spawned player " + playerNumber + "on " + teamColor);
                numberOfPlayersOnBlue++;
                break;

            default:
                Debug.Log("Incorrect Parameter passed through Initiate Player, was: " + teamColor);
                break;
        }

        
    }
}
