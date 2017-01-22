using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIMaster : MonoBehaviour
{
    [Header ("UI Elements")]
	public Text redTeamScoreUI;
	public Text blueTeatScoreUI;
	public Text timeDisplayUI;

	[Header ("Find The Timer")]
	public GameObject scriptThatDoesTimerGO;

	private int timeDisplay;

	void Update ()
    {
        ManageTimeUI();
        ManageTeamScore();
	}

    void ManageTimeUI()
    {
        timeDisplay = scriptThatDoesTimerGO.GetComponent<ScriptThatJustManagesTheTimeThatsIt>().timeLeft;
        string minutes = Mathf.Floor(timeDisplay / 60).ToString("00");
        string seconds = (timeDisplay % 60).ToString("00");
        timeDisplayUI.text = (minutes + ":" + seconds);
    }

    void ManageTeamScore()
    {
        redTeamScoreUI.text = ScoreTracker.redTeamCurrentScore.ToString();
        blueTeatScoreUI.text = ScoreTracker.blueTeamCurrentScore.ToString();
    }
}
