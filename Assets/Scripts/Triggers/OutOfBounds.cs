using System.Collections;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Ball":
                other.gameObject.transform.position = Vector3.zero;
                other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;

                Debug.Log("Ball fell Out Of Bounds, Reseting Ball to Origin");
                break;
            default:
                Debug.Log("Something unlisted passed through the OutOfBounds Trigger, was " + other.gameObject.name);
                break;
        }

    }
}
