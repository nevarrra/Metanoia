using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticInteraction : MonoBehaviour
{
    public AudioSource[] audiosLore;
    public AudioSource[] audiosRandom;
    public GameObject player;
    public float radiusOfInteraction;

    private bool playMusic = false;
    private float updateDistance;

    private float distance;
    private int randomNumber;
    private int audiosLoreIndex;
    private int audiosRandomIndex;

    private void Update()
    {
        distance = Vector3.Distance(transform.position, player.transform.position);

        if((distance <= radiusOfInteraction) && (playMusic == false))
        {
            playMusic = true;

            /*MUSIC LOGIC*/
            if (audiosLoreIndex == audiosLore.Length)
            {
                randomNumber = Random.Range(0, 51);
                if (randomNumber <= 25)
                {
                    audiosRandom[audiosRandomIndex].Play();
                    audiosRandomIndex += 1;
                }
                else
                {
                    audiosRandomIndex = 0;
                    audiosRandom[audiosRandomIndex].Play();
                }
            }
            else
            {
                if (audiosLoreIndex <= audiosLore.Length)
                {
                    audiosLore[audiosLoreIndex].Play();
                    audiosLoreIndex += 1;
                }
            }
            
            playMusic = true;
            /*MUSIC LOGIC*/
        }
        if (distance > radiusOfInteraction)
        {
            playMusic = false;
        }
    }

    /*
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            if (audiosLoreIndex == audiosLore.Length) {

                randomNumber = Random.Range(0, 51);
                if (randomNumber <= 25)
                {
                    audiosRandom[audiosRandomIndex].Play();
                    audiosRandomIndex += 1;
                }
                else
                {
                    audiosRandomIndex = 0;
                    audiosRandom[audiosRandomIndex].Play();
                }
            }
            else
            {
                if(audiosLoreIndex <= audiosLore.Length)
                {
                    audiosLore[audiosLoreIndex].Play();
                    audiosLoreIndex += 1;
                }
            }
        
        }
    }
    */
}
