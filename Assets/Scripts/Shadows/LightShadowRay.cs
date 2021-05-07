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
        float closestDistance = Mathf.Infinity;
        int closestLightId = 0;

        for (int i = 0; i < lights.Length; i++)
        {
            float distance = Vector3.Distance(transform.position, lights[i].transform.position);

            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestLightId = i;
            }
        }

        origin = lights[closestLightId].transform.position;

        if (Physics.Linecast(origin, transform.position, out RaycastHit hit))
        {
            if (hit.collider.gameObject.CompareTag("Shadow"))
            {
                Debug.Log("colidir");
                control.CanSeeShadow();
            }
        }
        //Debug.Log("AA");
        Debug.DrawRay(origin,transform.position - origin);

        //Debug.Log(origin);
    }

}
