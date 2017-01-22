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
    public Text winText;

    public string redWinText;
    public string blueWinText;

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

    public void DisplayWin(string winTeam)
    {
        switch(winTeam)
        {
            case "Red":
                winText.enabled = true;
                winText.text = redWinText;
                break;
            case "Blue":
                winText.enabled = true;
                winText.text = blueWinText;
                break;
        }
    }
}
