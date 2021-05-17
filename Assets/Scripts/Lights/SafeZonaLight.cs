using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZonaLight : MonoBehaviour
{
    private GameObject player;
    private ControlAndMovement control;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        control = player.GetComponent<ControlAndMovement>();
    }    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            control.isCollidingWithLight = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            control.isCollidingWithLight = false;
        }
    }
    
}
