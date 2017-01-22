using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIMaster : MonoBehaviour
{
    private ScriptThatJustManagesTheTimeThatsIt gameTime;

    [Header ("UI Elements")]
	public Text redTeamScoreUI;
	public Text blueTeatScoreUI;
	public Text timeDisplayUI;

	[Header ("Find The Timer")]
	public GameObject scriptThatDoesTimerGO;

	private int timeDisplay;

    void Start()
    {
        gameTime = GameObject.FindGameObjectWithTag("GameTime").GetComponent<ScriptThatJustManagesTheTimeThatsIt>();
    }

	void Update ()
    {
        ManageTimeUI();
        ManageTeamScore();
	}

    void ManageTimeUI()
    {
        timeDisplay = gameTime.timeLeft;
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
