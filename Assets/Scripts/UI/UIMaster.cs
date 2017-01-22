using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMaster : MonoBehaviour {

	[Header ("UI Elements")]
	public Text redTeamScoreUI;
	public Text blueTeatScoreUI;
	public Text scoreDisplay;

	[Header ("Find The Timer")]
	public GameObject scriptThatDoesTimerGO;

	private int timeDisplay;
	private


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		timeDisplay = scriptThatDoesTimerGO.GetComponent<ScriptThatJustManagesTheTimeThatsIt> ().timeLeft;
		string minutes = Mathf.Floor(timeDisplay / 60).ToString("00");
		string seconds = (timeDisplay % 60).ToString("00");
		scoreDisplay.text = (minutes +  ":" + seconds);
	}
}
