using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Camera))]
public class AllMenus : MonoBehaviour
{
    public GameObject pressStartEmpty;
    public GameObject pressAnyButtonToStart;
    public GameObject mainMenu;
    public GameObject creditMenu;

    public RawImage[] mainMenuButtons;
    public Text[] mainMenuText;

    public GameObject creditsMenu;

    public Texture menuButtonWhite;
    public Texture menuButtonNormal;

    private int menuScreenIndex = 0;
    private int menuOptionIndex = 0;
    private int optionMenuIndex = 0;
    private int animationIndex = 0;
    private float timeToNext = 0.0434f;
    private float timeToNextInitial = 0.0434f;

    private bool blinking = false;
    //Bools of the menu
    private bool turnOn = false;
    private bool turnOff = false;

    private bool mainMenuBool = true;
    private bool optionsBool = false;
    private bool creditsBool = false;
    private bool quitBool = false;

    private float[] blinkingAnimation = {0f, 0.05f, 0.1f, 0.15f, 0.2f, 0.25f, 0.3f, 0.35f, 0.4f, 0.45f,0.5f, 0.55f,
                                            0.6f, 0.65f, 0.7f, 0.75f, 0.8f, 0.85f,0.9f, 0.95f,1f,
                                            0.95f, 0.90f, 0.85f, 0.80f, 0.75f, 0.7f, 0.65f, 0.6f, 0.55f, 0.5f,
                                            0.45f, 0.40f, 0.35f, 0.3f, 0.25f,0.20f, 0.15f,0.10f,0.05f, 0f};
    
    private float[] turnOnAnimation = {0f, 0f, 0.05f, 0.1f, 0.15f, 0.2f, 0.25f, 0.3f, 0.35f, 0.4f, 0.45f,0.5f, 0.55f,
                                             0.6f, 0.65f, 0.7f, 0.75f, 0.8f, 0.85f,0.9f, 0.95f, 1f, 1f};

    private float[] turnOffAnimation = {1f, 1f, 0.95f, 0.90f, 0.85f, 0.80f, 0.75f, 0.7f, 0.65f, 0.6f, 0.55f, 0.5f,
                                            0.45f, 0.40f, 0.35f, 0.3f, 0.25f,0.20f, 0.15f,0.10f,0.05f, 0f, 0f};


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //Debug.Log(animationIndex);

        switch (menuScreenIndex)
        {
            case 0:
                AnyButton();
                break;
            case 1:
                AnyButtonOff();
                break;
            case 2:
                MainMenuOn();
                break;
            case 3:
                MainMenu();
                break;
            case 4:
                MainMenuOff();
                break;
            case 5:
                OptionsMenuOn();
                break;
            case 6:
                OptionsMenu();
                break;
            case 7:
                OptionsMenuOff();
                break;
            case 8:
                SoundMenuOn();
                break;
            case 9:
                SoundMenu();
                break;
            case 10:
                SoundMenuOff();
                break;
            case 11:
                ControlMenuOn();
                break;
            case 12:
                ControlMenu();
                break;
            case 13:
                ControlMenuOff();
                break;
            case 14:
                CreditsMenuOn();
                break;
            case 15:
                CreditsMenu();
                break;
            case 16:
                CreditsMenuOff();
                break;
        }

        if (animationIndex >= 22) 
        {
            animationIndex = 0;
        }
    
    }
    
    private void AnyButton()
    {
        RawImage rawPress = pressAnyButtonToStart.GetComponent<RawImage>();

            Color alpha = rawPress.color;
            alpha.a = blinkingAnimation[animationIndex];
            rawPress.color = alpha;

        timeToNext -= Time.deltaTime;

        if (timeToNext <= 0)
        {
            animationIndex += 1;
            timeToNext = timeToNextInitial;
        }

        if (animationIndex == blinkingAnimation.Length - 1)
        {
            animationIndex = 0;
        }

        if (Input.anyKey)
        {
            menuScreenIndex = 1;
            turnOff = true;
            animationIndex = 0;
        }
    }

    private void AnyButtonOff()
    {
        GameObject background = pressStartEmpty.transform.GetChild(1).gameObject;
        RawImage rawBackground = background.GetComponent<RawImage>();

            Color alphaBack = rawBackground.color;
            alphaBack.a = turnOffAnimation[animationIndex];
            rawBackground.color = alphaBack;

        GameObject logo = pressStartEmpty.transform.GetChild(2).gameObject;
        RawImage rawLogo = logo.GetComponent<RawImage>();

            Color alphalogo = rawLogo.color;
            alphalogo.a = turnOffAnimation[animationIndex];
            rawLogo.color = alphalogo;

        timeToNext -= Time.deltaTime;

        if (timeToNext <= 0)
        {
            animationIndex += 1;
            timeToNext = timeToNextInitial;
        }

        if (animationIndex == turnOffAnimation.Length - 1)
        {
            menuScreenIndex = 2;
            animationIndex = 0;
            timeToNext = timeToNextInitial;
            
            mainMenu.SetActive(true);
            pressAnyButtonToStart.SetActive(false);
        }
    }

    private void MainMenuOn()
    {
        ////////Logo
        GameObject logo = mainMenu.transform.GetChild(0).gameObject;
        RawImage logoRaw = logo.GetComponent<RawImage>();

            Color alphaLogo = logoRaw.color;
            alphaLogo.a = turnOnAnimation[animationIndex];
            logoRaw.color = alphaLogo;

        ////////Button Start
        GameObject start = mainMenu.transform.GetChild(1).gameObject;
        RawImage startRaw = start.GetComponent<RawImage>();

            Color alphaStart = startRaw.color;
            alphaStart.a = turnOnAnimation[animationIndex];
            startRaw.color = alphaStart;

        //Text Start
        GameObject startTextGameObject = start.transform.GetChild(0).gameObject;
        Text startText = startTextGameObject.GetComponent<Text>();

            Color alphaStartText = startText.color;
            alphaStartText.a = turnOnAnimation[animationIndex];
            startText.color = alphaStartText;

        //Button Options
        GameObject optionsGameObject = mainMenu.transform.GetChild(2).gameObject;
        RawImage optionsraw = optionsGameObject.GetComponent<RawImage>();

            Color alphaOptions = optionsraw.color;
            alphaOptions.a = turnOnAnimation[animationIndex];
            optionsraw.color = alphaOptions;

        ////////Options Text
        GameObject optionsTextGameObject = optionsGameObject.transform.GetChild(0).gameObject;
        Text optionsText = optionsTextGameObject.GetComponent<Text>();

            Color alphaOptionsText = optionsText.color;
            alphaOptionsText.a = turnOnAnimation[animationIndex];
            optionsText.color = alphaOptionsText;


        //Button Credits
        GameObject creditsGameObject = mainMenu.transform.GetChild(3).gameObject;
        RawImage creditsraw = creditsGameObject.GetComponent<RawImage>();

            Color alphaCredits = creditsraw.color;
            alphaCredits.a = turnOnAnimation[animationIndex];
            creditsraw.color = alphaCredits;

        ////////Credits Text
        GameObject crecitsTextGameObject = creditsGameObject.transform.GetChild(0).gameObject;
        Text creditsText = crecitsTextGameObject.GetComponent<Text>();

            Color alphaCreditsText = creditsText.color;
            alphaCreditsText.a = turnOnAnimation[animationIndex];
            creditsText.color = alphaCreditsText;

        //Button Quit
        GameObject quit = mainMenu.transform.GetChild(4).gameObject;
        RawImage quitRaw = quit.GetComponent<RawImage>();

            Color alphaQuit = quitRaw.color;
            alphaQuit.a = turnOnAnimation[animationIndex];
            quitRaw.color = alphaQuit;

        ////////Quit Text
        GameObject quitTextGameObject = quit.transform.GetChild(0).gameObject;
        Text quitText = quitTextGameObject.GetComponent<Text>();

            Color alphaQuitText = quitText.color;
            alphaQuitText.a = turnOnAnimation[animationIndex];
            quitText.color = alphaQuitText;

        timeToNext -= Time.deltaTime;

        //Debug.Log(animationIndex);

        if (timeToNext <= 0)
        {
            animationIndex += 1;
            timeToNext = timeToNextInitial;
        }

        if ((animationIndex == turnOnAnimation.Length - 1) && (mainMenuBool == true))
        {
            menuScreenIndex = 3;
            animationIndex = 0;
            timeToNext = timeToNextInitial;
        }
    }

    private void MainMenu()
    {
        //W & S to change optionIndex
        if (Input.GetKeyDown("w"))
        {
            menuOptionIndex -= 1;
        }
        if (Input.GetKeyDown("s"))
        {
            menuOptionIndex += 1;
        }

        /* BACK TO INITIAL OPTION */
        if (menuOptionIndex < 0)
        {
            menuOptionIndex = 3;
        }
        if (menuOptionIndex > mainMenuButtons.Length - 1)
        {
            menuOptionIndex = 0;
        }
        /*BACK TO INITIAL OPTION*/

        for (int i = 0; i < mainMenuButtons.Length; i++)
        {
            if (i == menuOptionIndex)
            {
                mainMenuButtons[menuOptionIndex].texture = menuButtonWhite;
                mainMenuText[menuOptionIndex].color = Color.black;
            }
            else
            {
                mainMenuButtons[i].texture = menuButtonNormal;
                mainMenuText[i].color = Color.white;
            }
        }

        //StartGame
        if ((menuOptionIndex == 0) && (Input.GetMouseButtonDown(0)))
        {
            SceneManager.LoadScene("Rocca Inside");
        }

        if ((menuOptionIndex == 1) && (Input.GetMouseButtonDown(0)))
        {
            menuOptionIndex = 0;
        }

        if ((menuOptionIndex == 2) && (Input.GetMouseButtonDown(0)))
        {
            mainMenuBool = false;
            creditsBool = true;
            menuScreenIndex = 4;
            animationIndex = 0;
        }

        if ((menuOptionIndex == 3) && (Input.GetMouseButtonDown(0)))
        {
            Application.Quit();
        }
    }

    private void MainMenuOff()
    {
        ////////Logo
        GameObject logo = mainMenu.transform.GetChild(0).gameObject;
        RawImage logoRaw = logo.GetComponent<RawImage>();

            Color alphaLogo = logoRaw.color;
            alphaLogo.a = turnOffAnimation[animationIndex];
            logoRaw.color = alphaLogo;

        ////////Button Start
        GameObject start = mainMenu.transform.GetChild(1).gameObject;
        RawImage startRaw = start.GetComponent<RawImage>();

            Color alphaStart = startRaw.color;
            alphaStart.a = turnOffAnimation[animationIndex];
            startRaw.color = alphaStart;

        //Text Start
        GameObject startTextGameObject = start.transform.GetChild(0).gameObject;
        Text startText = startTextGameObject.GetComponent<Text>();

            Color alphaStartText = startText.color;
            alphaStartText.a = turnOffAnimation[animationIndex];
            startText.color = alphaStartText;

        //Button Options
        GameObject optionsGameObject = mainMenu.transform.GetChild(2).gameObject;
        RawImage optionsraw = optionsGameObject.GetComponent<RawImage>();

            Color alphaOptions = optionsraw.color;
            alphaOptions.a = turnOffAnimation[animationIndex];
            optionsraw.color = alphaOptions;

        ////////Options Text
        GameObject optionsTextGameObject = optionsGameObject.transform.GetChild(0).gameObject;
        Text optionsText = optionsTextGameObject.GetComponent<Text>();

            Color alphaOptionsText = optionsText.color;
            alphaOptionsText.a = turnOffAnimation[animationIndex];
            optionsText.color = alphaOptionsText;


        //Button Credits
        GameObject creditsGameObject = mainMenu.transform.GetChild(3).gameObject;
        RawImage creditsraw = creditsGameObject.GetComponent<RawImage>();

            Color alphaCredits = creditsraw.color;
            alphaCredits.a = turnOffAnimation[animationIndex];
            creditsraw.color = alphaCredits;

        ////////Credits Text
        GameObject crecitsTextGameObject = creditsGameObject.transform.GetChild(0).gameObject;
        Text creditsText = crecitsTextGameObject.GetComponent<Text>();

            Color alphaCreditsText = creditsText.color;
            alphaCreditsText.a = turnOffAnimation[animationIndex];
            creditsText.color = alphaCreditsText;

        //Button Quit
        GameObject quit = mainMenu.transform.GetChild(4).gameObject;
        RawImage quitRaw = quit.GetComponent<RawImage>();

            Color alphaQuit = quitRaw.color;
            alphaQuit.a = turnOffAnimation[animationIndex];
            quitRaw.color = alphaQuit;

        ////////Quit Text
        GameObject quitTextGameObject = quit.transform.GetChild(0).gameObject;
        Text quitText = quitTextGameObject.GetComponent<Text>();

            Color alphaQuitText = quitText.color;
            alphaQuitText.a = turnOffAnimation[animationIndex];
            quitText.color = alphaQuitText;

        timeToNext -= Time.deltaTime;

        if (timeToNext <= 0)
        {
            animationIndex += 1;
            timeToNext = timeToNextInitial;
        }

        if ((animationIndex == turnOnAnimation.Length - 1) && (optionsBool == true))
        {
            menuScreenIndex = 5;
            animationIndex = 0;
            timeToNext = timeToNextInitial;
            mainMenu.SetActive(false);
        }

        if ((animationIndex == turnOnAnimation.Length - 1) && (creditsBool == true))
        {
            menuScreenIndex = 14;
            animationIndex = 0;
            timeToNext = timeToNextInitial;
            mainMenu.SetActive(false);
            creditMenu.SetActive(true);
        }

    }

    private void OptionsMenuOn()
    {
        //DO IT HERE
    }
    private void OptionsMenu()
    {

    }
    private void OptionsMenuOff()
    {

    }
    private void SoundMenuOn()
    {

    }
    private void SoundMenu()
    {

    }
    private void SoundMenuOff()
    {

    }
    private void ControlMenuOn()
    {

    }
    private void ControlMenu()
    {

    }

    private void ControlMenuOff()
    {

    }

    private void CreditsMenuOn()
    {
        //////LOGOS
        GameObject logo = creditMenu.transform.GetChild(0).gameObject;
        
        //Metanoia Logo
        GameObject metanoia = logo.transform.GetChild(0).gameObject;
        RawImage metaLogo = metanoia.GetComponent<RawImage>();

            Color alphaMetaLogo = metaLogo.color;
            alphaMetaLogo.a = turnOnAnimation[animationIndex];
            metaLogo.color = alphaMetaLogo;

        //Merakkie Logo
        GameObject merakkie = logo.transform.GetChild(1).gameObject;
        RawImage meraLogo = merakkie.GetComponent<RawImage>();

            Color alphaMeraLogo = meraLogo.color;
            alphaMeraLogo.a = turnOnAnimation[animationIndex];
            meraLogo.color = alphaMeraLogo;
        
        //Unity Logo
        GameObject unity = logo.transform.GetChild(2).gameObject;
        RawImage unityLogo = unity.GetComponent<RawImage>();

            Color alphaUnity = unityLogo.color;
            alphaUnity.a = turnOnAnimation[animationIndex];
            unityLogo.color = alphaUnity;

        //Epidemic Logo
        GameObject epidemic = logo.transform.GetChild(3).gameObject;
        RawImage epicLogo = epidemic.GetComponent<RawImage>();

            Color alphaEpic = epicLogo.color;
            alphaEpic.a = turnOnAnimation[animationIndex];
            epicLogo.color = alphaEpic;

        //////BACK BUTTON
        GameObject backFather = creditMenu.transform.GetChild(1).gameObject;

        GameObject backText = backFather.transform.GetChild(0).gameObject;
        Text back = backText.GetComponent<Text>();

            Color alphaBack = back.color;
            alphaBack.a = turnOnAnimation[animationIndex];
            back.color = alphaBack;

        //////LINES
        GameObject lines = creditMenu.transform.GetChild(2).gameObject;

        GameObject line0 = lines.transform.GetChild(0).gameObject;
        RawImage line0Raw = line0.GetComponent<RawImage>();
        
            Color alphaline0 = line0Raw.color;
            alphaline0.a = turnOnAnimation[animationIndex];
            line0Raw.color = alphaline0;

        GameObject line1 = lines.transform.GetChild(1).gameObject;
        RawImage line1Raw = line1.GetComponent<RawImage>();

            Color alphaline1 = line1Raw.color;
            alphaline1.a = turnOnAnimation[animationIndex];
            line1Raw.color = alphaline1;

        GameObject line2 = lines.transform.GetChild(2).gameObject;
        RawImage line2Raw = line2.GetComponent<RawImage>();

            Color alphaline2 = line2Raw.color;
            alphaline2.a = turnOnAnimation[animationIndex];
            line2Raw.color = alphaline2;

        GameObject line3 = lines.transform.GetChild(3).gameObject;
        RawImage line3Raw = line3.GetComponent<RawImage>();

            Color alphaline3 = line3Raw.color;
            alphaline3.a = turnOnAnimation[animationIndex];
            line3Raw.color = alphaline3;

        timeToNext -= Time.deltaTime;

        if (timeToNext <= 0)
        {
            animationIndex += 1;
            timeToNext = timeToNextInitial;
        }

        if (animationIndex == turnOffAnimation.Length - 1)
        {
            menuScreenIndex = 15;
            animationIndex = 0;
            timeToNext = timeToNextInitial;
        }
    }
    private void CreditsMenu()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //menuOptionIndex = 0;
            menuScreenIndex = 16;
            animationIndex = 0;
            creditsBool = false;
        }
    }
    private void CreditsMenuOff()
    {
        //////LOGOS
        GameObject logo = creditMenu.transform.GetChild(0).gameObject;

        //Metanoia Logo
        GameObject metanoia = logo.transform.GetChild(0).gameObject;
        RawImage metaLogo = metanoia.GetComponent<RawImage>();

            Color alphaMetaLogo = metaLogo.color;
            alphaMetaLogo.a = turnOffAnimation[animationIndex];
            metaLogo.color = alphaMetaLogo;

        //Merakkie Logo
        GameObject merakkie = logo.transform.GetChild(1).gameObject;
        RawImage meraLogo = merakkie.GetComponent<RawImage>();

            Color alphaMeraLogo = meraLogo.color;
            alphaMeraLogo.a = turnOffAnimation[animationIndex];
            meraLogo.color = alphaMeraLogo;

        //Unity Logo
        GameObject unity = logo.transform.GetChild(2).gameObject;
        RawImage unityLogo = unity.GetComponent<RawImage>();

            Color alphaUnity = unityLogo.color;
            alphaUnity.a = turnOffAnimation[animationIndex];
            unityLogo.color = alphaUnity;

        //Epidemic Logo
        GameObject epidemic = logo.transform.GetChild(3).gameObject;
        RawImage epicLogo = epidemic.GetComponent<RawImage>();

            Color alphaEpic = epicLogo.color;
            alphaEpic.a = turnOffAnimation[animationIndex];
            epicLogo.color = alphaEpic;

        //////BACK BUTTON
        GameObject backFather = creditMenu.transform.GetChild(1).gameObject;

        GameObject backText = backFather.transform.GetChild(0).gameObject;
        Text back = backText.GetComponent<Text>();

            Color alphaBack = back.color;
            alphaBack.a = turnOffAnimation[animationIndex];
            back.color = alphaBack;

        //////LINES
        GameObject lines = creditMenu.transform.GetChild(2).gameObject;

        GameObject line0 = lines.transform.GetChild(0).gameObject;
        RawImage line0Raw = line0.GetComponent<RawImage>();

            Color alphaline0 = line0Raw.color;
            alphaline0.a = turnOffAnimation[animationIndex];
            line0Raw.color = alphaline0;

        GameObject line1 = lines.transform.GetChild(1).gameObject;
        RawImage line1Raw = line1.GetComponent<RawImage>();

            Color alphaline1 = line1Raw.color;
            alphaline1.a = turnOffAnimation[animationIndex];
            line1Raw.color = alphaline1;

        GameObject line2 = lines.transform.GetChild(2).gameObject;
        RawImage line2Raw = line2.GetComponent<RawImage>();

            Color alphaline2 = line2Raw.color;
            alphaline2.a = turnOffAnimation[animationIndex];
            line2Raw.color = alphaline2;

        GameObject line3 = lines.transform.GetChild(3).gameObject;
        RawImage line3Raw = line3.GetComponent<RawImage>();

            Color alphaline3 = line3Raw.color;
            alphaline3.a = turnOffAnimation[animationIndex];
            line3Raw.color = alphaline3;

        timeToNext -= Time.deltaTime;

        if (timeToNext <= 0)
        {
            animationIndex += 1;
            timeToNext = timeToNextInitial;
        }

        if (animationIndex == turnOffAnimation.Length - 1)
        {
            animationIndex = 0;
            menuScreenIndex = 2;
            timeToNext = timeToNextInitial;
            mainMenuBool = true;
            mainMenu.SetActive(true);
            creditMenu.SetActive(false);
        }
    }


}
