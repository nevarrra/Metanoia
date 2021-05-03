using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightShadowRay : MonoBehaviour
{
    public GameObject[] lights;
    public Vector3 directionShadowLight;
    public Vector3 origin;
    public float[] distanceLight;

    public ControlAndMovement control;

    private int closesLighttIndex;

    void Start()
    {
        origin = Vector3.zero;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RayCastLightShadow();
    }

    public void RayCastLightShadow()
    {
        for (int i = 0; i < lights.Length; i++)
        {
            directionShadowLight = transform.position - origin;

            distanceLight[i] = Vector3.Distance(transform.position, lights[i].transform.position);
            Array.Sort(distanceLight);

            if (Vector3.Distance(transform.position, lights[i].transform.position) == distanceLight[0])
            {
                origin = lights[i].transform.position;
                //Debug.Log("update origin");
            }

            RaycastHit hit;
            if (Physics.Raycast(origin, directionShadowLight, out hit, 20f))
            {
                if (hit.collider.gameObject.tag == "Shadow")
                {
                    //Debug.Log("Colliding");
                    //Debug.Log(hit.collider.tag);
                    control.CanSeeShadow();
                }
            }
            //Debug.DrawRay(origin, directionShadowLight);
        }
    }

}
