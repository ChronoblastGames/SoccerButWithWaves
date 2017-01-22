using System.Collections;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private PlayerController playerController;

    [Header("Player Info")]
    public string playerNumber;

    [Header("Player Controls")]
    public float xAxis;
    public float yAxis;

    public KeyCode Interact;
    public KeyCode INTERACT_CONTROLLER;
    public KeyCode Pause;

    public bool canMove;
    public bool canGetInput;

	void Start ()
    {
        GetPlayerInfo();
	}
	
	void Update ()
    {
        GetInput();
	}

    void GetPlayerInfo()
    {
        playerNumber = tag;

        playerController = GetComponent<PlayerController>();
    }

    void GetInput()
    {
        if (canGetInput)
        {
            if (canMove)
            {
                xAxis = Input.GetAxis("Horizontal" + playerNumber);

                yAxis = Input.GetAxis("Vertical" + playerNumber);
            }

            if (Input.GetKeyDown(Pause))
            {

            }

            if (Input.GetKeyDown(Interact) || Input.GetButtonDown("Fire"+playerNumber))
            {
                playerController.CreateWave();
            }
        }
    }
}
