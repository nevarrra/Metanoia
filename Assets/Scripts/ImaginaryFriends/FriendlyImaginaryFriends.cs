using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class FriendlyImaginaryFriends: MonoBehaviour
{

    //Public
    //Sentences
    public string[] sentencesText;
    //Option Images And Text
    public RawImage[] optionsRawImages;
    public Text[] optionsText;
    public GameObject ifInteraction;
    public GameObject ifOptions;
    public Text sentenceUI;

    //Waypoints
    public Transform[] waypoints;

    //Get item colleted and 

    //Item he wants + Player info + Shadow
    public Item itemRequested;
    public GameObject player;
    public GameObject Shadow;
    public State interactingState;

    //Private
    private SelectionRay selected;
    private ControlAndMovement control;
    private FSM fsm;

    private int waypointIndex = 0;
    private int sentencesTextIndex = 0;
    //Options related Indexes
    public int optionsIndex = 0;
    private int startIndex = 0;
    private int lastIndex = 2;
    private NavMeshAgent agent;

    

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        fsm = GetComponent<FSM>();

        selected = player.GetComponent<SelectionRay>();

        control = player.GetComponent<ControlAndMovement>();
    }

    // Update is called once per frame
    void Update()
    {

        if (fsm.currentState == interactingState)
        {
            //Stop NPC
            agent.SetDestination(transform.position);
            //Lock to the payer
            transform.LookAt(player.transform.position);

            if (Input.GetKeyDown("e"))
            {
                //turn on text & image
                ifInteraction.SetActive(true);
                //Turn on interacting
                control.interacting = true;
            }
        }
        else
        {
            //Go Back to patrol
            Invoke("Walking", 3f);
            //turn on text & image
            ifInteraction.SetActive(false);
            //turn on options
            ifOptions.SetActive(false);
            //Turn on interacting
            control.interacting = false;
        }
        //Get boolean of interaction from Player to stop moving
        if(control.interacting == true)
        {
            Interacting();
        }
        else
        {
            Walking();
        }
    }

    //waypoint index += 1, that's it, cry later
    public void Walking()
    {
        if (transform.position.x == waypoints[waypointIndex].position.x)
        {
            if (waypointIndex == waypoints.Length - 1)
            {
                waypointIndex = 0;
            }
            else
            {
                waypointIndex += 1;
            }
        }
        agent.SetDestination(waypoints[waypointIndex].position);
    }

    private void Interacting()
    {
        if ((sentencesTextIndex) == (sentencesText.Length - 1))
        {
            Request();
        }
        else
        {
            
            Talking();
        }
    }

    public void Request() 
    {
        
        //Activate Options
        ifOptions.SetActive(true);

        //W & S to change optionIndex
        if (Input.GetKeyDown("w") == true)
        {
            optionsIndex -= 1;
        }
        if (Input.GetKeyDown("s") == true)
        {
            optionsIndex += 1;
        }

        //Change the color to show the option activated
        for (int i = 0; i < optionsRawImages.Length; i++)
        {
            if (i == optionsIndex)
            {
                optionsRawImages[optionsIndex].color = Color.red;
                optionsText[optionsIndex].color = Color.red;
            }
            else
            {
                optionsRawImages[i].color = Color.white;
                optionsText[i].color = Color.white;
            }
        }

        //Give item player has
        if ((optionsIndex == 0) && (Input.GetMouseButtonDown(0)))
        {
            //correct item to correct request
            if (itemRequested == selected.itemColleted)
            {
                //Destroy npc
                Destroy(gameObject, 2f);
                //turn off text & image
                ifInteraction.SetActive(false);
                //turn off options
                ifOptions.SetActive(false);
                //Turn off interacting
                control.interacting = false;
            }
            else
            {
                //Destroy npc
                Destroy(gameObject, 2f);
                //turn on text & image
                ifInteraction.SetActive(false);
                //turn on options
                ifOptions.SetActive(false);
                //Turn off interacting
                control.interacting = false;
                //Active Shadow
                Shadow.SetActive(true);
            }
        }

        if ((optionsIndex == 1) && (Input.GetMouseButtonDown(0)))
        {
            //Destroy npc
            Destroy(gameObject, 2f);
            //turn off text & image
            ifInteraction.SetActive(false);
            //turn off options
            ifOptions.SetActive(false);
            //Turn off interacting
            control.interacting = false;
            //Active Shadow
            Shadow.SetActive(true);
        }

        if ((optionsIndex == 2) && (Input.GetMouseButtonDown(0)))
        {
            //Go back to patrol
            Invoke("Walking", 3f);
            //turn off text & image
            ifInteraction.SetActive(false);
            //turn off options
            ifOptions.SetActive(false);
            //Turn off interacting
            control.interacting = false;
        }

        /* BACK TO INITIAL OPTION */
        if (optionsIndex < startIndex)
        {
            optionsIndex = 2;
        }
        if (optionsIndex > lastIndex)
        {
            optionsIndex = 0;
        }
        /*BACK TO INITIAL OPTION*/
    }


    public void Talking()
    {
        // Press Left click to next sentence
        if (Input.GetMouseButtonDown(0))
        {
            sentencesTextIndex += 1;
        }
        sentenceUI.text = sentencesText[sentencesTextIndex];
    }
}
