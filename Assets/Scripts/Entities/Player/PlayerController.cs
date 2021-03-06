﻿using System.Collections;
using UnityEngine;

[RequireComponent(typeof (InputManager))]
[RequireComponent(typeof (Rigidbody))]

public class PlayerController : MonoBehaviour
{
    private InputManager inputManager;
	private Timer waveTimer;
	[SerializeField]
	private bool canWave;
	public float waveDelay = 1.25f;

    private Rigidbody myRB;

    [Header("Player Movement Attributes")]
    private float xAxis;
    private float yAxis;
    public float moveSpeed;
    private float baseMoveSpeed;

    [Header("Player Stamina Attributes")]
    public float currentStamina;
    private float maxStamina = 100f;
    public float staminaRegenerationRate;
    public float staminaCostPerSecond;

    [Header("Player Wave Attributes")]
    public float explosionStrength;
    public float explosionRadius;
    public LayerMask explosionMask;

    [Header("Player Color Attributes")]
    public Color playerColor;

    void Start ()
    {
		waveTimer = new Timer ();
		waveTimer.ResetTimer (0);
        PlayerSetup();
	}
	
	void FixedUpdate ()
    {
        GatherInputs();

		if (waveTimer.TimerIsDone()) {
			
			canWave = true;
		}
	}

    void PlayerSetup()
    {
        myRB = GetComponent<Rigidbody>();

        inputManager = GetComponent<InputManager>();

        playerColor = GetComponent<Material>().color;
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

    void ManageStamina()
    {
        if (currentStamina < maxStamina)
        {
            currentStamina += staminaRegenerationRate * Time.deltaTime;
        }
        else if (currentStamina > maxStamina)
        {
            currentStamina = maxStamina;
        }      
    }

    void Move(float xAxis, float yAxis)
    {
        if (xAxis > 0.4 || xAxis < -0.4)
        {
            myRB.AddForce(Vector3.right * xAxis * moveSpeed * Time.deltaTime, ForceMode.Impulse);
        }

        if (yAxis > 0.4 || yAxis < -0.4)
        {
            myRB.AddForce(Vector3.forward * yAxis * moveSpeed * Time.deltaTime, ForceMode.Impulse);
        }
    }

    public void CreateWave()
    {
		if (canWave == true) {
			Vector3 explosionVec = transform.position;

			Collider[] explosionDetection = Physics.OverlapSphere (explosionVec, explosionRadius, explosionMask);

			foreach (Collider hit in explosionDetection) {
				Rigidbody hitRB = hit.gameObject.GetComponent<Rigidbody> ();

				if (hitRB != null) {
					hitRB.AddExplosionForce (explosionStrength, explosionVec, explosionRadius, 0f, ForceMode.Impulse);
				}

				RippleEffect.instance.EmitAtPosition (explosionVec, playerColor);
			}
			waveTimer.ResetTimer (waveDelay);
			canWave = false;
		}
    }
}
