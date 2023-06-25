using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraInput : MonoBehaviour
{
    public void DisableInput()
    {
        GetComponent<CinemachineBrain>().enabled = false;
    }

    public void EnableInput()
    {
        GetComponent<CinemachineBrain>().enabled = true;
    }
}
