using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class ResetCameraPosition : MonoBehaviour
{

    [SerializeField] private CinemachineFreeLook cinemachineFreeLook;
    
    // Start is called before the first frame update
    void Start()
    {
        cinemachineFreeLook.m_YAxis.Value = 0.5f;
        cinemachineFreeLook.m_XAxis.Value = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
