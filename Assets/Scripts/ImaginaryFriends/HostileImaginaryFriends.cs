using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class HostileImaginaryFriends : MonoBehaviour
{

    //Questionaries 
    //Last one is que question
    public string[] firstQuestionary;
    public string[] optionsFirstQuestionary;
    public int answerFirstQuestionary;

    public string[] secondQuestionary;
    public string[] optionsSecondQuestionary;
    public int answerSecondQuestionary;

    public string[] thirdQuestionary;
    public string[] optionsThirdQuestionary;
    public Item itemRequested;

    //Waypoints
    public Transform[] waypoints;
    public int waypointIndex;

    //Options && Text
    public GameObject HIInteractions;
    public GameObject HIOptions;
    public RawImage[] options;
    public Text sentenceUI;
    public Text[] optionsText;

    //Scripts
    public GameObject player;
    public GameObject Shadow;
    public State interactingState;

    //private && getStuff
    private NavMeshAgent agent;
    private SelectionRay selected;
    private ControlAndMovement control;
    private FSM fsm;
    //Options Index
    private int fQuestionaryIndex = 0;
    private int sQuestionaryIndex = 0;
    private int tQuestionaryIndex = 0;

    private bool HIOptionAndSentence = false;

    private int optionsIndex = 0;
    private int startIndex = 0;
    private int lastIndex = 2;
    private int ActiveQuestionary = 0;
    //Index String Index


    


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
            if (Input.GetKeyDown("e"))
            {
                if (ActiveQuestionary == 7)
                {
                    control.interacting = true;
                    HIOptionAndSentence = true;
                    HIInteractions.SetActive(HIOptionAndSentence);
                    //turn on options
                    HIOptions.SetActive(HIOptionAndSentence);
                    ActiveQuestionary = 6;
                }
                else
                {
                    control.interacting = true;
                    ActiveQuestionary = 1;
                    //turn on text & image
                    HIInteractions.SetActive(true);
                    //Turn on interacting
                    control.interacting = true;
                }
            }
        }

        switch (ActiveQuestionary)
        {
            case 0:
                Walking();
                break;
            case 1:
                FirstQuestionary();
                break;
            case 2:
                AnswerFirsQuestionary();
                break;
            case 3:
                SecondQuestionary();
                break;
            case 4:
                AswerSecondQuestionary();
                break;
            case 5:
                ThirdQuestionary();
                break;
            case 6:
                AswerThirdQuestionary();
                break;
            case 7:
                TurnItAllOff();
                break;
        }
    }

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

    public void FirstQuestionary()
    {
        //Activate * (-1) Options
        HIOptions.SetActive(HIOptionAndSentence);
        // Press Left click to next sentence
        if (Input.GetMouseButtonDown(0))
        {
            fQuestionaryIndex += 1;
            if (fQuestionaryIndex == firstQuestionary.Length - 1)
            {
                ActiveQuestionary += 1;
            }
        }
        sentenceUI.text = firstQuestionary[fQuestionaryIndex];
    }

    public void AnswerFirsQuestionary()
    {
        HIOptionAndSentence = true;
        //Activate Options
        HIOptions.SetActive(HIOptionAndSentence);

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
        for (int i = 0; i < options.Length; i++)
        {
            optionsText[i].text = optionsFirstQuestionary[i];
            if (i == optionsIndex)
            {
                options[optionsIndex].color = Color.red;
                optionsText[optionsIndex].color = Color.red;
            }
            else
            {
                options[i].color = Color.white;
                optionsText[i].color = Color.white;
            }
        }

        if ((optionsIndex == answerFirstQuestionary) && (Input.GetMouseButtonDown(0)))
        {
            Debug.Log("Respondeu certo");
            ActiveQuestionary += 1;
        }
        if ((optionsIndex != answerFirstQuestionary) && (Input.GetMouseButtonDown(0)))
        {
            Debug.Log("Respondeu errado");
            ActiveQuestionary += 1;
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

    public void SecondQuestionary()
    {
        //Activate * (-1) Options
        HIOptions.SetActive(false);

        // Press Left click to next sentence
        if (Input.GetMouseButtonDown(0))
        {
            sQuestionaryIndex += 1;
            if (sQuestionaryIndex == secondQuestionary.Length - 1)
            {
                ActiveQuestionary += 1;
            }
        }
        sentenceUI.text = secondQuestionary[sQuestionaryIndex];
    }

    public void AswerSecondQuestionary()
    {
        HIOptionAndSentence = true;
        //Activate Options
        HIOptions.SetActive(true);

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
        for (int i = 0; i < options.Length; i++)
        {
            optionsText[i].text = optionsSecondQuestionary[i];
            if (i == optionsIndex)
            {
                options[optionsIndex].color = Color.red;
                optionsText[optionsIndex].color = Color.red;
            }
            else
            {
                options[i].color = Color.white;
                optionsText[i].color = Color.white;
            }
        }

        if ((optionsIndex == answerSecondQuestionary) && (Input.GetMouseButtonDown(0)))
        {
            Debug.Log("Respondeu certo");
            ActiveQuestionary += 1;
            HIOptionAndSentence = false;
        }
        if ((optionsIndex != answerSecondQuestionary) && (Input.GetMouseButtonDown(0)))
        {
            Debug.Log("Respondeu errado");
            ActiveQuestionary += 1;
            HIOptionAndSentence = false;
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

    public void ThirdQuestionary()
    {
        //Activate * (-1) Options
        HIOptions.SetActive(HIOptionAndSentence);

        // Press Left click to next sentence
        if (Input.GetMouseButtonDown(0))
        {
            tQuestionaryIndex += 1;
            if (tQuestionaryIndex == thirdQuestionary.Length - 1)
            {
                ActiveQuestionary += 1;
            }
        }
        sentenceUI.text = thirdQuestionary[tQuestionaryIndex];
    }

    public void AswerThirdQuestionary()
    {
        HIOptionAndSentence = true;
        //Activate Options
        HIOptions.SetActive(HIOptionAndSentence);

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
        for (int i = 0; i < options.Length; i++)
        {
            optionsText[i].text = optionsThirdQuestionary[i];
            if (i == optionsIndex)
            {
                options[optionsIndex].color = Color.red;
                optionsText[optionsIndex].color = Color.red;
            }
            else
            {
                options[i].color = Color.white;
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
                Destroy(gameObject, 1f);
                //Turn Off
                ActiveQuestionary += 1;
                ////Consequence\\\\

            }
            else
            {
                //Destroy npc
                Destroy(gameObject, 1f);
                //Turn Off
                ActiveQuestionary += 1;
                ////Consequence\\\\

                //Active Shadow
                Shadow.SetActive(true);
            }
        }

        if ((optionsIndex == 1) && (Input.GetMouseButtonDown(0)))
        {
            //Destroy npc
            Destroy(gameObject, 1f);
            //Turn Off
            ActiveQuestionary += 1;
            ////Consequence\\\\

            //Active Shadow
            Shadow.SetActive(true);
        }

        if ((optionsIndex == 2) && (Input.GetMouseButtonDown(0)))
        {

            //Turn off interacting
            control.interacting = false;

            ActiveQuestionary += 1;
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

    private void TurnItAllOff()
    {
        HIOptionAndSentence = false;
        //turn off options
        HIOptions.SetActive(HIOptionAndSentence);
        //Turn off interacting
        HIInteractions.SetActive(HIOptionAndSentence);
        control.interacting = false;
    }
    
    private void OnTriggerStay(Collider collider)
    {
        if (collider.tag == "Player")
        {
            //Stop NPC
            agent.SetDestination(transform.position);
            //Lock to the payer
            transform.LookAt(player.transform.position);

            if (Input.GetKeyDown("e"))
            {
                if (ActiveQuestionary == 7)
                {
                    control.interacting = true;
                    HIOptionAndSentence = true;
                    HIInteractions.SetActive(HIOptionAndSentence);
                    //turn on options
                    HIOptions.SetActive(HIOptionAndSentence);
                    ActiveQuestionary = 6;
                }
                else
                {
                    ActiveQuestionary = 1;
                    //turn on text & image
                    HIInteractions.SetActive(true);
                    //Turn on interacting
                    control.interacting = true;
                }
            }
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Player")
        {
            Walking();
            HIOptionAndSentence = false;
            //turn on text & image
            HIInteractions.SetActive(HIOptionAndSentence);
            //turn on options
            HIOptions.SetActive(HIOptionAndSentence);
            //Turn on interacting
            control.interacting = false;
        }
    }

}
