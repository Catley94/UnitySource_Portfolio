using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Highlight : MonoBehaviour
{
    private Light pointLight;
    // Start is called before the first frame update
    void Start()
    {
        pointLight = GetComponentInChildren<Light>();
        pointLight.color = GetComponent<Renderer>().material.color;;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Animal"))
        {
            pointLight.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Animal"))
        {
            pointLight.enabled = false;
        }
    }
}
