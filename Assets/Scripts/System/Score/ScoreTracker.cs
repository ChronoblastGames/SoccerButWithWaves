using System.Collections;
using UnityEngine;

public class ScoreTracker : MonoBehaviour
{
    [Header("Score Attributes")]
    public static int redTeamCurrentScore;
    public static int blueTeamCurrentScore;

    public static int maxScore;

    static void ResetScore()
    {
        redTeamCurrentScore = 0;
        blueTeamCurrentScore = 0;
    }

    static void AddPoint(string team)
    {
        switch(team)
        {
            case "Red":
                redTeamCurrentScore++;
                CheckForWin();
                break;
            case "Blue":
                blueTeamCurrentScore++;
                CheckForWin();
                break;
        }
    }

    static void CheckForWin()
    {
        if (redTeamCurrentScore >= maxScore)
        {
            Debug.Log("Red Team Wins!");
        }
        else if (blueTeamCurrentScore >= maxScore)
        {
            Debug.Log("Blue Team Wins");
        }
    }
}
