using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BreathingUI : MonoBehaviour
{
    public ControlAndMovement player;
    private float speed;
    public GameObject buttonPrefab;
    public Transform buttonInstantiate;
    private List<GameObject> buttons;
    private GameObject newButton;
    public GameObject pointer;
    private float instantiateTimer;
    private int successNr;
    private float generalTimer;
    public CameraControl cam;
    private bool panelActive;

    void Start()
    {
        speed = 180f;
        buttons = new List<GameObject>();
        instantiateTimer = 0f;
        successNr = 0;
        generalTimer = 60f;
        
        // list of buttons

    }

    private void OnEnable()
    {
        panelActive = true;
    }

    void InstantiateButtons()
    {
        if (instantiateTimer <= 0)
            {
            newButton = Instantiate(buttonPrefab, buttonInstantiate.localPosition, Quaternion.identity);
            newButton.transform.SetParent(this.transform, false);
            buttons.Add(newButton);
            instantiateTimer = Random.Range(0.7f, 1.7f);
            }
        instantiateTimer-= Time.deltaTime;
        // run random timer
        // instantiate a button
        // Add it to list
    }

    public bool IsUIActive()
    {
        return panelActive;
    }

    Rect GetWorldSpaceRect(RectTransform rct)
    {
        var r = rct.rect;
        r.center = rct.TransformPoint(r.center);
        r.size = rct.TransformVector(r.size);
        return r;
    }

    void RunButtons()
    {
        GameObject pressedBtn = null;
        foreach (GameObject button in buttons)
        {
            //Debug.Log(GetWorldSpaceRect(pointer.GetComponent<RectTransform>()).Overlaps(GetWorldSpaceRect(button.GetComponent<RectTransform>())));
            button.transform.Translate(Vector3.left * speed * Time.deltaTime);
            if(Input.GetKeyDown(KeyCode.E))
            {
                if(ButtonIntersects(button))
                {
                    successNr += 1;
                    pressedBtn = button;
                }
                //disable button
            }

            if (successNr >= 5 || successNr <= -5)
            {
                GameObject.Destroy(button);
            }
        }

        if(pressedBtn == null && Input.GetKeyDown(KeyCode.E))
        {
            successNr -= 1;
        }

       

        if (pressedBtn != null)
        {
            buttons.Remove(pressedBtn);
            GameObject.Destroy(pressedBtn, 0.1f);
        }
    }

    public int GetSuccessNr()
    {
        return successNr;
    }

    void PlayerWins()
    {
//        GameObject.Destroy(gameObject);
        cam.RestoreCamera();
        //player.ResetHeartbeat();
        Debug.Log(player.heartBeat);
        ResetHeartbeat();
        buttons.Clear();
        successNr = 0;
        panelActive = false;
        gameObject.SetActive(false);
        
        // raise camera back
    }

    public void ResetHeartbeat()
    {
        int value = (int)player.heartBeat - 120;
        player.heartBeat -= value;
    }

    void EndGame()
    {
        buttons.Clear();
        successNr = 0;
        //GameObject.Destroy(gameObject);
        gameObject.SetActive(false);

        //death cutscene here
    }

    bool ButtonIntersects(GameObject currButton)
    {
        
        return (GetWorldSpaceRect(pointer.GetComponent<RectTransform>()).Overlaps(GetWorldSpaceRect(currButton.GetComponent<RectTransform>())));
       

        // change bool to clicked
    }


    void Update()
    {
        generalTimer -= Time.deltaTime;
        if(generalTimer > 0)
        {
            InstantiateButtons();
            RunButtons();
            cam.Invoke("BreathingEffect", 2.5f);
            //cam.BreathingEffect();
            if (successNr >= 5)
            {
                PlayerWins();
            }
            else if (successNr <= -5)
            {
                EndGame();
            }
        }
       
        
        //clickArea
    }
}

