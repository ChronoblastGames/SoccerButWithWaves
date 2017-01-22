using System.Collections;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [Header("Goal Attributes")]
    public bool isRedGoal;
    public bool isBlueGoal;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            if (isRedGoal)
            {
                ScoreTracker.AddPoint("Blue");
            }
            else if (isBlueGoal)
            {
                ScoreTracker.AddPoint("Red");
            }
        }
    }
}
