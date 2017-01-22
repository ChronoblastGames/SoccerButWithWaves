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
                xAxis = Input.GetAxisRaw("Horizontal" + playerNumber);

                yAxis = Input.GetAxisRaw("Vertical" + playerNumber);
            }
            else
            {
                xAxis = 0;
                yAxis = 0;
            }

            if (Input.GetKeyDown(Pause))
            {

            }

            if (Input.GetKeyDown(Interact))
            {
                playerController.CreateWave();
            }
        }
    }
}
