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
    public int answerThirdQuestionary;

    //Waypoints
    public Transform[] waypoints;

    //Options && Text
    public GameObject HIInteractions;
    public GameObject HIOptions;
    public RawImage[] options;
    public Text sentenceUI;
    public Text[] optionsText;

    //Scripts
    public GameObject player;
    public GameObject Shadow;
    public SelectionRay selected;
    public ControlAndMovement control;

    //private && getStuff
    private NavMeshAgent agent;
    //Options Index
    private int startIndex = 0;
    private int lastIndex = 2;
    private int optionIndex;
    //Index String Index
    private int FQuestionIndex = 0;
    private int SQuestionIndex = 0;
    private int TQuestionIndex = 0;

    //bool for each questionary
    private bool fQuestionary = true;
    private bool answerFirstQ = false;

    private bool sQuestionary = false;
    private bool answerSecondQ = false;

    private bool tQuestionary = false;
    private bool answerThirdQ = false;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //Questions  
        if ((FQuestionIndex != firstQuestionary.Length - 1) && (fQuestionary == true) && (answerFirstQ = false))
        {
            Debug.Log("F Questionary");
            FirstQuestionary();
        }
        //Answers
        if ((FQuestionIndex ==  firstQuestionary.Length - 1) && (fQuestionary == false) && (answerFirstQ == true))
        {

            AnswerFirsQuestionary();          
        }

        //Questions  
        if ((SQuestionIndex != secondQuestionary.Length - 1) && (sQuestionary == true) && (answerSecondQ == false))
        {
            Debug.Log("S Questionary");
            SecondQuestionary();
        }
        //Answers
        if ((SQuestionIndex == secondQuestionary.Length) && (sQuestionary == false) && (answerSecondQ == true))
        {
            AswerSecondQuestionary();
        }

        //Questions  
        if ((TQuestionIndex != thirdQuestionary.Length - 1) && (tQuestionary = true) && (answerThirdQ == false))
        {
            Debug.Log("T Questionary");
            ThirdQuestionary();
        }
        //Answers
        if ((TQuestionIndex == thirdQuestionary.Length - 1) && (tQuestionary == false) && (answerThirdQ = true))
        {
            AswerThirdQuestionary();
        }

    }

    public void FirstQuestionary()
    {
        // Press Left click to next sentence
        if (Input.GetMouseButtonDown(0))
        {
            FQuestionIndex += 1;
            if (FQuestionIndex == firstQuestionary.Length - 1)
            {
                fQuestionary = false;
                answerFirstQ = true;
            }
        }
        sentenceUI.text = firstQuestionary[FQuestionIndex];
    }

    public void AnswerFirsQuestionary()
    {
        //Activate Options
        HIOptions.SetActive(true);

        //W & S to change optionIndex
        if (Input.GetKeyDown("w") == true)
        {
            optionIndex -= 1;
        }
        if (Input.GetKeyDown("s") == true)
        {
            optionIndex += 1;
        }

        //Change the color to show the option activated
        for (int i = 0; i < options.Length; i++)
        {
            optionsText[i].text = optionsFirstQuestionary[i];

            if (i == optionIndex)
            {
                options[optionIndex].color = Color.red;
                optionsText[optionIndex].color = Color.red;
            }
            else
            {
                options[i].color = Color.white;
                optionsText[i].color = Color.white;
            }
        }


        if ((optionIndex == 0) && (Input.GetMouseButtonDown(0)))
        {
            
        }

        if ((optionIndex == 1) && (Input.GetMouseButtonDown(0)))
        {
           
        }

        if ((optionIndex == 2) && (Input.GetMouseButtonDown(0)))
        {
            //Go back to patrol
            Invoke("Walking", 3f);
            //turn off text & image
            HIInteractions.SetActive(false);
            //turn off options
            HIOptions.SetActive(false);
            //Turn off interacting
            control.interacting = false;
        }

        /* BACK TO INITIAL OPTION */
        if (optionIndex < startIndex)
        {
            optionIndex = 2;
        }
        if (optionIndex > lastIndex)
        {
            optionIndex = 0;
        }
        /*BACK TO INITIAL OPTION*/
    }

    public void SecondQuestionary()
    {
        // Press Left click to next sentence
        if (Input.GetMouseButtonDown(0))
        {
            SQuestionIndex += 1;
        }
        sentenceUI.text = secondQuestionary[SQuestionIndex];
    }

    public void AswerSecondQuestionary()
    {
        //Activate Options
        HIOptions.SetActive(true);

        //W & S to change optionIndex
        if (Input.GetKeyDown("w") == true)
        {
            optionIndex -= 1;
        }
        if (Input.GetKeyDown("s") == true)
        {
            optionIndex += 1;
        }

        //Change the color to show the option activated
        for (int i = 0; i < options.Length; i++)
        {
            if (i == optionIndex)
            {
                options[optionIndex].color = Color.red;
                optionsText[optionIndex].color = Color.red;
            }
            else
            {
                options[i].color = Color.white;
                optionsText[i].color = Color.white;
            }
        }
    }

    public void ThirdQuestionary()
    {
        // Press Left click to next sentence
        if (Input.GetMouseButtonDown(0))
        {
            TQuestionIndex += 1;
        }
        sentenceUI.text = thirdQuestionary[TQuestionIndex];
    }

    public void AswerThirdQuestionary()
    {
        //Activate Options
        HIOptions.SetActive(true);

        //W & S to change optionIndex
        if (Input.GetKeyDown("w") == true)
        {
            optionIndex -= 1;
        }
        if (Input.GetKeyDown("s") == true)
        {
            optionIndex += 1;
        }

        //Change the color to show the option activated
        for (int i = 0; i < options.Length; i++)
        {
            optionsText[i].text = optionsThirdQuestionary[i];
            if (i == optionIndex)
            {
                options[optionIndex].color = Color.red;
                optionsText[optionIndex].color = Color.red;
            }
            else
            {
                options[i].color = Color.white;
                optionsText[i].color = Color.white;
            }
        }

        //Give item player has
        if ((optionIndex == 0) && (Input.GetMouseButtonDown(0)))
        {
            //correct item to correct request
            /*
            if (itemRequested == selected.itemColleted)
            {
                //Destroy npc
                Destroy(gameObject, 2f);
                //turn off text & image
                HIInteractions.SetActive(false);
                //turn off options
                HIOptions.SetActive(false);
                //Turn off interacting
                control.interacting = false;
            }
            else
            {
                //Destroy npc
                Destroy(gameObject, 2f);
                //turn on text & image
                HIInteractions.SetActive(false);
                //turn on options
                HIOptions.SetActive(false);
                //Turn off interacting
                control.interacting = false;
                //Active Shadow
                Shadow.SetActive(true);
            }
            */
        }

        if ((optionIndex == 1) && (Input.GetMouseButtonDown(0)))
        {
            //Destroy npc
            Destroy(gameObject, 2f);
            //turn off text & image
            HIInteractions.SetActive(false);
            //turn off options
            HIOptions.SetActive(false);
            //Turn off interacting
            control.interacting = false;
            //Active Shadow
            Shadow.SetActive(true);
        }

        if ((optionIndex == 2) && (Input.GetMouseButtonDown(0)))
        {
            //Go back to patrol
            Invoke("Walking", 3f);
            //turn off text & image
            HIInteractions.SetActive(false);
            //turn off options
            HIOptions.SetActive(false);
            //Turn off interacting
            control.interacting = false;
        }

        /* BACK TO INITIAL OPTION */
        if (optionIndex < startIndex)
        {
            optionIndex = 2;
        }
        if (optionIndex > lastIndex)
        {
            optionIndex = 0;
        }
        /*BACK TO INITIAL OPTION*/

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
                //turn on text & image
                HIInteractions.SetActive(true);
                //Turn on interacting
                control.interacting = true;
            }
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Player")
        {
            //Go Back to patrol
            //Invoke("Walking", 3f);
            //turn on text & image
            HIInteractions.SetActive(false);
            //turn on options
            HIOptions.SetActive(false);
            //Turn on interacting
            control.interacting = false;
        }
    }

}
