using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;


public class SpeechManager : MonoBehaviour
{
    public TMP_Text captions;
    private TextAsset Script;
    private float displayTime = 0f;
    private Queue<Sentence> sentences = new Queue<Sentence>();
    private Sentence currentSentence;

    public void TriggeredSpeech(GameObject NPC, int speechNumber)
    {
        NarrationList narrations = JsonUtility.FromJson<NarrationList>(Script.text);
        
        var nr = narrations.narrations
            .Where(n => NPC.name == n.name)
            .FirstOrDefault(n => n.speechNr == speechNumber);

        if (nr == null)
        {
            return;
        }

        nr.sentences.ForEach(s => sentences.Enqueue(s));
    }

    void Start()
    {
        Script = Resources.Load("SpeechScript") as TextAsset;
    }

    // Update is called once per frame
    void Update()
    {
        if(!sentences.Any() && currentSentence == null)
        {
            displayTime = 0;
            captions.text = "";
            return;
        }

        if (currentSentence == null)
        {
            currentSentence = sentences.Dequeue();
        }

        captions.text = currentSentence.text;
        displayTime += Time.deltaTime;

        if (displayTime >= currentSentence.end - currentSentence.start)
        {
            displayTime = 0;
            currentSentence = null;
        }
    }

}




