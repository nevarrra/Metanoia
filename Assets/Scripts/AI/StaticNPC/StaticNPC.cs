using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticNPC : MonoBehaviour
{
    public SpeechManager narrations;
    public GameObject player;
    public int ID;
    private bool hasExecuted;
    private int speechNumber;
    public int flowercount;

    void Start()
    {
        speechNumber = 1;

    }
    private void GoThoughSpeeches()
    {
        if (Vector3.Distance(player.transform.position, transform.position) <= 10f && !hasExecuted)
        {
            if(ID == 1)
            {
                if (flowercount < 3)
                    narrations.TriggeredSpeech(gameObject, Random.Range(1, 4));
                else
                    narrations.TriggeredSpeech(gameObject, 5);
            }
            else
            {
                narrations.TriggeredSpeech(gameObject, speechNumber);
                             
            }
            hasExecuted = true;
            speechNumber += 1;

        }
        else if (Vector3.Distance(player.transform.position, transform.position) >= 50f)
        {
            hasExecuted = false;
            narrations.StopCaptions();
        }
    }

    void Update()
    {
        GoThoughSpeeches();
        
        //Debug.Log(hasExecuted);
    }
}
