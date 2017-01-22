using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextImpulse : MonoBehaviour
{
    void Update()
    {
        transform.localScale = new Vector3(Mathf.Lerp(transform.localScale.x, Mathf.PingPong(Time.time,1f), Time.deltaTime), Mathf.Lerp(transform.localScale.y, Mathf.PingPong(Time.time, 1f), Time.deltaTime), 0f);
    }
}
