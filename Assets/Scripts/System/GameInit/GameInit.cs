using System.Collections;
using UnityEngine;

public class GameInit : MonoBehaviour
{
    private MainMenuController mainMenuController;

    [Header("Map Setup Attributes")]
    private int numberOfPlayers;

    public GameObject[] redTeamSpawns;
    public GameObject[] blueTeamSpawns;

    public GameObject[] playerList;

    void Awake()
    {
        mainMenuController = GameObject.FindGameObjectWithTag("GameController").GetComponent<MainMenuController>();

        int numberOfRedPlayers = mainMenuController.redTeamList.Count;
        int numberOfBluePlayers = mainMenuController.blueTeamList.Count;
    }

    void SpawnPlayers()
    {
        
    }
}
