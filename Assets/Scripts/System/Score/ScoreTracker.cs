using System.Collections;
using UnityEngine;

public class ScoreTracker : MonoBehaviour
{
    [Header("Score Attributes")]
    public static int redTeamCurrentScore;
    public static int blueTeamCurrentScore;

    public static int maxScore = 5;

    public static GameObject ball;

    void Start()
    {
        ball = GameObject.FindGameObjectWithTag("Ball");
    }

    static void ResetScore()
    {
        redTeamCurrentScore = 0;
        blueTeamCurrentScore = 0;
    }

    public static void ResetBall()
    {
        ball.transform.position = Vector3.zero;
        ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
        ball.GetComponent<TrailRenderer>().Clear();
    }

    public static void AddPoint(string team)
    {
        switch(team)
        {
            case "Red":
                redTeamCurrentScore++;
                CheckForWin();
                ResetBall();
                break;
            case "Blue":
                blueTeamCurrentScore++;
                CheckForWin();
                ResetBall();
                break;
        }
    }

    public static void CheckForWin()
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
