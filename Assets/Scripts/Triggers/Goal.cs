using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    CameraShake2D cameraShake2D;

    [Header("Debug")]
    public float camDuration;
    public float camAmp;
    public float camDecay;

    void Awake()
    {
        cameraShake2D = GameObject.Find("Main Camera").GetComponent<CameraShake2D>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("RedGoalTrigger"))
        {
            print("GOLLL");
            ScoreTracker.AddPoint("Blue");
            cameraShake2D.ShakeCamera(camDuration, camAmp, camDecay);
        }

        if (other.transform.CompareTag("BlueGoalTrigger"))
        {
            print("GOLLL");
            ScoreTracker.AddPoint("Red");
            cameraShake2D.ShakeCamera(camDuration, camAmp, camDecay);
        }
    }
}
