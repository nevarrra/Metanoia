using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nurse : MonoBehaviour
{
    public SpeechManager narrations;
    public GameObject player;
    public GameObject door;
    private bool hasExecuted;
    private int flowers;
    // Start is called before the first frame update
    void Start()
    {
        flowers = player.GetComponent<SelectionRay>().GetFlowersCount();
    }

    public void GoThoughSpeeches()
    {
        if (Vector3.Distance(player.transform.position, gameObject.transform.position) <= 10f && !hasExecuted)
        {
            int randSpeech = Random.Range(1, 4);
            if (flowers < 3)
            {
                narrations.TriggeredSpeech(gameObject, randSpeech);
            }
            else
            {
                narrations.TriggeredSpeech(gameObject, 5);
                Object.Destroy(door, 2);
            }              

            hasExecuted = true;
        }
        if (Vector3.Distance(player.transform.position, gameObject.transform.position) >= 20f)
        {
            hasExecuted = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        GoThoughSpeeches();
    }
}
