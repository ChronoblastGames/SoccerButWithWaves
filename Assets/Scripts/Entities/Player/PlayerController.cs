using System.Collections;
using UnityEngine;

[RequireComponent(typeof (InputManager))]
[RequireComponent(typeof (Rigidbody))]

public class PlayerController : MonoBehaviour
{
    private InputManager inputManager;

    private Rigidbody myRB;

    [Header("Player Movement Attributes")]
    private float xAxis;
    private float yAxis;
    public float moveSpeed;
    private float baseMoveSpeed;

    [Header("Player Stamina Attributes")]
    public float currentStamina;
    public float staminaRegenerationRate;
    public float staminaCostPerSecond;
    
	void Start ()
    {
        PlayerSetup();
	}
	
	void FixedUpdate ()
    {
        GatherInputs();
	}

    void PlayerSetup()
    {
        myRB = GetComponent<Rigidbody>();

        inputManager = GetComponent<InputManager>();
    }

    void GatherInputs()
    {
        xAxis = inputManager.xAxis;
        yAxis = inputManager.yAxis;

        if (xAxis != 0 || yAxis != 0)
        {
            Move(xAxis, yAxis);
        }
    }

    void Move(float xAxis, float yAxis)
    {
        if (xAxis != 0)
        {
            myRB.AddForce(Vector3.right * xAxis * moveSpeed * Time.deltaTime, ForceMode.Impulse);
        }

        if (yAxis != 0)
        {
            myRB.AddForce(Vector3.forward * yAxis * moveSpeed * Time.deltaTime, ForceMode.Impulse);
        }
    }
}
