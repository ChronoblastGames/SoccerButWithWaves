using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptThatJustManagesTheTimeThatsIt : MonoBehaviour {
	[HideInInspector]
	public Timer gameTimer;

	public float gameLength;
	public int timeLeft;

	// Use this for initialization
	void Start () {
		gameTimer = new Timer (gameLength);
	}
	
	// Update is called once per frame
	void Update () {
		if (gameTimer.TimerIsDone ()) {
			Debug.Log ("GAME SHOULD BE DONE NOW");
			StopGame ();
		}
		timeLeft = Mathf.RoundToInt((gameLength-(gameTimer.GetRatio()* gameLength)));
	}

	public void StopGame(){
		Time.timeScale = 0;
	}
}
