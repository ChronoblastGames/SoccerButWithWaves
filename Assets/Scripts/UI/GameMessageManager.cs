using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMessageManager : MonoBehaviour {

	//SendToEndGameMenu;
	public Text textToDisplay;
	public string redTeamWins;
	public string blueTeamWins;
	public string drawText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void DisplayMessage(string messageToSend){
		switch(messageToSend){
		case "RedWin":
			textToDisplay.text = redTeamWins;
			break;
		case "BlueWin":
			textToDisplay.text = blueTeamWins;
			break;
		case "Draw":
			textToDisplay.text = drawText;
			break;
		default:
			break;
		}

	}
}
