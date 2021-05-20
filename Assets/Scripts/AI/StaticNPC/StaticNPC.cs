using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticNPC : MonoBehaviour
{
    public SpeechManager narrations;
    public GameObject player;
    private bool hasExecuted;

    void Start()
    {
        hasExecuted = false;
    }

    void Update()
    {
        if (Vector3.Distance(player.transform.position, transform.position) <= 20f && !hasExecuted)
        {
            narrations.TriggeredSpeech(gameObject, 2);
            hasExecuted = true;
        }
        //Debug.Log(hasExecuted);
    }
}
