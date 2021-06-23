﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject UIGame;
    public GameObject selector;
    public Texture whiteOption;
    public Texture blackOption;

    public RawImage[] pauseButtons;
    public Text[] pauseText;

    private ControlAndMovement control;

    Controller controls;

    private float timeToNext = 0.0434f;
    private float timeToNextInitial = 0.0434f;

    private int pauseOrder = 0;
    private int options = 0;
    private int arrayIndex = 0;
    public bool isPaused = false;
    private float[] on = { 0f, 0f, 0.05f, 0.1f, 0.15f, 0.2f, 0.25f, 0.3f, 0.35f, 0.4f, 0.45f, 0.45f };
    private float[] off = { 0.45f, 0.45f, 0.4f, 0.35f, 0.3f, 0.25f, 0.2f, 0.15f, 0.10f, 0.5f, 0f, 0f };
    // New Input System:
    bool currentClick;
    Vector2 currentMovement;
    bool movementPressed;

    private void Awake()
    {
        controls = new Controller();
        controls.Gameplay.Escape.performed += ctx =>
        {
            currentClick = ctx.ReadValueAsButton();
        };
        controls.Gameplay.Move.performed += ctx =>
        {
            currentMovement = ctx.ReadValue<Vector2>();
            movementPressed = currentMovement.y != 0;
        };
    }

    void Start()
    {
        control = GetComponent<ControlAndMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (pauseOrder)
        {
            case 0:
                InGame();
                break;
            case 1:
                TurnOn();
                break;
            case 2:
                Pause();
                break;
            case 3:
                TurnOff();
                break;
        }
    }

    private void InGame()
    {

        if ((currentClick) && (control.interacting == false) && (pauseOrder == 0))
        {
            isPaused = true;  
        }

        if (isPaused == true)
        {
            control.interacting = true;
            pauseOrder = 1;
            
            pauseMenu.SetActive(true);
            UIGame.SetActive(false);
            selector.SetActive(false);
        }
    }

    private void TurnOn()
    {
        GameObject background = pauseMenu.transform.GetChild(0).gameObject;
        RawImage backgroundImage = background.GetComponent<RawImage>();

        Color alphaback = backgroundImage.color;
        alphaback.a = on[arrayIndex];
        backgroundImage.color = alphaback;

        GameObject metanoia = pauseMenu.transform.GetChild(1).gameObject;
        RawImage metanoiaLogo = metanoia.GetComponent<RawImage>();

            Color alphaMeta = metanoiaLogo.color;
            alphaMeta.a = on[arrayIndex];
            metanoiaLogo.color = alphaMeta;

        GameObject merakkie = pauseMenu.transform.GetChild(2).gameObject;
        RawImage merakkieLogo = merakkie.GetComponent<RawImage>();

            Color alphaMera = merakkieLogo.color;
            alphaMera.a = on[arrayIndex];
            merakkieLogo.color = alphaMera;

        GameObject pauseOption1 = pauseMenu.transform.GetChild(3).gameObject;
        RawImage pauseOption11 = pauseOption1.GetComponent<RawImage>();

            Color alphaOp1 = pauseOption11.color;
            alphaOp1.a = on[arrayIndex];
            pauseOption11.color = alphaOp1;

        GameObject pauseOption2 = pauseMenu.transform.GetChild(4).gameObject;
        RawImage pauseOption21 = pauseOption2.GetComponent<RawImage>();

            Color alphaOp2 = pauseOption21.color;
            alphaOp2.a = on[arrayIndex];
            pauseOption21.color = alphaOp2;

        GameObject pauseOption3 = pauseMenu.transform.GetChild(5).gameObject;
        RawImage pauseOption31 = pauseOption3.GetComponent<RawImage>();

            Color alphaOp3 = pauseOption31.color;
            alphaOp3.a = on[arrayIndex];
            pauseOption31.color = alphaOp3;
        
        GameObject pauseOption1Text = pauseMenu.transform.GetChild(6).gameObject;
        Text pauseOption11Text = pauseOption1Text.GetComponent<Text>();

            Color alphaOpText = pauseOption11Text.color;
            alphaOpText.a = on[arrayIndex];
            pauseOption11Text.color = alphaOpText;

        GameObject pauseOption2Text = pauseMenu.transform.GetChild(7).gameObject;
        Text pauseOption21Text = pauseOption2Text.GetComponent<Text>();

            Color alphaOp2Text = pauseOption21Text.color;
            alphaOp2Text.a = on[arrayIndex];
            pauseOption21Text.color = alphaOp2Text;

        GameObject pauseOption3Text = pauseMenu.transform.GetChild(8).gameObject;
        Text pauseOption31Text = pauseOption3Text.GetComponent<Text>();

            Color alphaOp3Text = pauseOption31Text.color;
            alphaOp3Text.a = on[arrayIndex];
            pauseOption31Text.color = alphaOp3Text;
        

        timeToNext -= Time.deltaTime;

        if (timeToNext <= 0)
        {
            //Debug.Log("Here");
            arrayIndex += 1;
            timeToNext = timeToNextInitial;
        }

        if ((arrayIndex == on.Length))
        {
            pauseMenu.SetActive(true);
            pauseOrder = 2;
            arrayIndex = 0;
            Time.timeScale = 0;

        }
    }

    private void Pause()
    {
        //W & S to change optionIndex
        if (currentMovement.y > 0)
        {
            options -= 1;
        }
        if (currentMovement.y < 0)
        {
            options += 1;
        }

        /* BACK TO INITIAL OPTION */
        if (options < 0)
        {
            options = 3;
        }
        if (options > pauseButtons.Length - 1)
        {
            options = 0;
        }
        /*BACK TO INITIAL OPTION*/

        for (int i = 0; i < pauseButtons.Length; i++)
        {
            if (i == options)
            {
                pauseButtons[options].texture = whiteOption;
                pauseText[options].color = Color.black;
            }
            else
            {
                pauseButtons[i].texture = blackOption;
                pauseText[i].color = Color.white;
            }
        }

        //StartGame
        if ((options == 0) && (Input.GetMouseButtonDown(0)))
        {
            isPaused = false;
            
            pauseOrder = 3;
            arrayIndex = 0;
            Time.timeScale = 1;
        }

        if ((options == 1) && (Input.GetMouseButtonDown(0)))
        {
            options = 0;
        }

        if ((options == 2) && (Input.GetMouseButtonDown(0)))
        {
            
            SceneManager.LoadScene("Menus");
            arrayIndex = 0;
            Time.timeScale = 1;
            control.interacting = false;
            isPaused = false;

        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = false;

            pauseOrder = 3;
            arrayIndex = 0;
            Time.timeScale = 1;
        }

    }

    private void TurnOff()
    {
        GameObject background = pauseMenu.transform.GetChild(0).gameObject;
        RawImage backgroundImage = background.GetComponent<RawImage>();

            Color alphaback = backgroundImage.color;
            alphaback.a = off[arrayIndex];
            backgroundImage.color = alphaback;

        GameObject metanoia = pauseMenu.transform.GetChild(1).gameObject;
        RawImage metanoiaLogo = metanoia.GetComponent<RawImage>();

            Color alphaMeta = metanoiaLogo.color;
            alphaMeta.a = off[arrayIndex];
            metanoiaLogo.color = alphaMeta;

        GameObject merakkie = pauseMenu.transform.GetChild(2).gameObject;
        RawImage merakkieLogo = merakkie.GetComponent<RawImage>();

            Color alphaMera = merakkieLogo.color;
            alphaMera.a = off[arrayIndex];
            merakkieLogo.color = alphaMera;

        GameObject pauseOption1 = pauseMenu.transform.GetChild(3).gameObject;
        RawImage pauseOption11 = pauseOption1.GetComponent<RawImage>();

            Color alphaOp1 = pauseOption11.color;
            alphaOp1.a = off[arrayIndex];
            pauseOption11.color = alphaOp1;

        GameObject pauseOption2 = pauseMenu.transform.GetChild(4).gameObject;
        RawImage pauseOption21 = pauseOption2.GetComponent<RawImage>();

            Color alphaOp2 = pauseOption21.color;
            alphaOp2.a = off[arrayIndex];
            pauseOption21.color = alphaOp2;

        GameObject pauseOption3 = pauseMenu.transform.GetChild(5).gameObject;
        RawImage pauseOption31 = pauseOption3.GetComponent<RawImage>();

            Color alphaOp3 = pauseOption31.color;
            alphaOp3.a = off[arrayIndex];
            pauseOption31.color = alphaOp3;

        GameObject pauseOption1Text = pauseMenu.transform.GetChild(6).gameObject;
        Text pauseOption11Text = pauseOption1Text.GetComponent<Text>();

            Color alphaOp1Text = pauseOption11Text.color;
            alphaOp1Text.a = off[arrayIndex];
            pauseOption11Text.color = alphaOp1Text;

        GameObject pauseOption2Text = pauseMenu.transform.GetChild(6).gameObject;
        Text pauseOption21Text = pauseOption2Text.GetComponent<Text>();

            Color alphaOp2Text = pauseOption21Text.color;
            alphaOp2Text.a = off[arrayIndex];
            pauseOption21Text.color = alphaOp2Text;

        GameObject pauseOption3Text = pauseMenu.transform.GetChild(6).gameObject;
        Text pauseOption31Text = pauseOption3Text.GetComponent<Text>();

            Color alphaOp3Text = pauseOption31Text.color;
            alphaOp3Text.a = off[arrayIndex];
            pauseOption31Text.color = alphaOp3Text;


        timeToNext -= Time.deltaTime;

        if (timeToNext <= 0)
        {
            arrayIndex += 1;
            timeToNext = timeToNextInitial;
        }

        if (arrayIndex == off.Length)
        {
            pauseMenu.SetActive(false);
            pauseOrder = 0;
            arrayIndex = 0;
            UIGame.SetActive(true);
            selector.SetActive(true);
            control.interacting = false;
        }
    }

}
