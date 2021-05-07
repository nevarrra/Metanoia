using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlAndMovement : MonoBehaviour
{
    /////Public\\\\
    public float movementSpeed = 8f;
    public bool isCollidingWithLight;

    public Camera cam;
    //HeartBeats
    public float heartBeat = 120;
    public int multiplicator = 2;
    //Shadows
    //public
    //Increase Walls
    public GameObject walls;
    //Distrance from shadows
    public GameObject[] shadows;
    public float[] distances;
    public float minDistance;
    //is interacting?
    public bool interacting = false;
    //GetMeshRendererFromShadows
    public MeshRenderer[] meshShadow;
    //Lights
    public Light[] lights;
    public Vector3[] screenShadowPoint;
    public Vector3[] screenLightPoint;
    public float[] distanceLight;
    public GameObject dist;

    private bool sawShadow;

    ////Private\\\\
    //Positions of the Camera
    private float[] cameraYPos = new float[] {0.70f, 0.69f, 0.68f, 0.67f, 0.66f, 0.65f, 0.64f, 0.63f, 0.62f, 0.61f, 0.60f, 0.61f, 0.62f, 0.63f, 0.64f, 0.65f, 0.66f, 0.67f, 0.68f, 0.69f, 0.70f};
    //CameraYPos Index
    private int cameraIndex = 0;
    //WallMultiplication
    private float wallMultiplicator;
    //Distance Detection HeartBeats
    private float heartBeatDis;
    ////Get Components\\\\
    private CharacterController controller;
    private Renderer render;
    


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    public void IncreaseHeartbeat(float amount)
    {
        heartBeat += amount;
    }

    public float GetHeartBeat()
    {
        return heartBeat;
    }
    
    public float GetHeartBeatDistance()
    {
        return heartBeatDis;
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Lights")
        {
            isCollidingWithLight = true;
        }
        
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Lights")
        {
            isCollidingWithLight = false;
        }
    }

    public bool CollidedWithLight()
    {
        return isCollidingWithLight;
    }

    //Fixed Update is better as have a smoother movement
    private void FixedUpdate()
    {
        Control();
        IncreasingHeartBeat();
        IncreasingHeartBeatDistance();
    }

    public void Control()
    {
        if (interacting == false)
        {

            //////////Movement && And Camera Behavior\\\\\\\\\\
            float movementX = Input.GetAxis("Vertical");
            float movementZ = Input.GetAxis("Horizontal");

            Vector3 move = transform.forward * movementX + transform.right * movementZ;

            controller.SimpleMove(move * movementSpeed);

            //Camemra "walking"\\
            cam.transform.localPosition = new Vector3(cam.transform.localPosition.x, cameraYPos[cameraIndex], cam.transform.localPosition.z);

            //Character Moves == Camera go Up && Down
            if (movementX != 0 || movementZ != 0)
            {
                cameraIndex += 1;

                if (cameraIndex == cameraYPos.Length)
                {
                    cameraIndex = 0;
                }
            }
            //Camemra "walking"\\
            //////////Movement && And Camera Behavior\\\\\\\\\\
        }
    }

    public void IncreasingHeartBeat()
    {
        if (CollidedWithLight())
        {
            return;
        }
        else
        {
            for (int i = 0; i < shadows.Length; i++)
            {
                distances[i] = Vector3.Distance(shadows[i].transform.position, transform.position);
                Array.Sort(distances);

                if ((distances[0] <= minDistance) || (distances[1] <= minDistance))
                {
                    heartBeat += multiplicator * Time.deltaTime;

                    wallMultiplicator = ((heartBeat - 120) / 120) + 1.6f;
                    walls.transform.localScale = new Vector3(1, wallMultiplicator, 1);
                }
            }
        }

        
    }
    
    public float IncreasingHeartBeatDistance()
    {
        heartBeatDis = heartBeat / 3;
        //dist.transform.localScale = new Vector3(heartBeatDis, heartBeatDis, heartBeatDis);
        return heartBeatDis;
        
    }

    public void CanSeeShadow()
    {
        for (int sha = 0; sha < shadows.Length; sha++)
        {
            for (int lig = 0; lig < lights.Length; lig++)
            {
                meshShadow[sha] = shadows[sha].GetComponent<MeshRenderer>();

                Vector3 screenShadowPoint = cam.WorldToViewportPoint(shadows[sha].transform.position);
                Vector3 screenLightPoint = cam.WorldToViewportPoint(lights[lig].transform.position);

                bool shadowOnScreen = screenShadowPoint.z > 0 && screenShadowPoint.x > -1.5f && screenShadowPoint.x < 1.5f && screenShadowPoint.y > -2.5f && screenShadowPoint.y < 2.5f;
                bool lightOnScreen = screenLightPoint.z > 0 && screenLightPoint.x > -1.5f && screenLightPoint.x < 1.5f && screenLightPoint.y > -2.5f && screenLightPoint.y < 2.5f;

                distanceLight[sha] = Vector3.Distance(transform.position, lights[sha].transform.position);
                Array.Sort(distanceLight);
                float distanceFromPrimaryLight = distanceLight[0];

                if ((shadowOnScreen == true) && (lightOnScreen == true) && (distanceFromPrimaryLight < 30f))
                {
                    //Debug.Log("see shadow");
                    meshShadow[sha].enabled = true;
                    sawShadow = true;
                }
                else
                {
                    //Debug.Log("can't see shadow else");
                    meshShadow[sha].enabled = false;
                    sawShadow = false;

                }
            }
        }
    }

    public bool SawShadow()
    {
        return sawShadow;
    }

}
