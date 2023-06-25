using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Serialization;

public class IsMobileDevice : MonoBehaviour
{
    [SerializeField] private GameObject joystickMovement;
    [FormerlySerializedAs("joystickCamera")] [SerializeField] private GameObject joystickCameraArea;
    [SerializeField] private GameObject mobileUI;

    private static bool isMobile = false;
    
    // Start is called before the first frame update
    void Awake()
    {
        #if !UNITY_EDITOR && UNITY_WEBGL
            Bridge.IsMobile += IsMobile;
            Debug.Log("Subbed to IsMobile");
            SendLocation.OnLocationChange += (location) => DisplayMobileUI();
        #endif
    }

    public void IsMobile()
    {
        isMobile = true;
        Debug.Log("IsMobileDevice: IsMobile = true");
    }

    public static bool GetIsMobile()
    {
        return isMobile;
    }

    private void DisplayMobileUI()
    {
        Debug.Log("Displaying Mobile UI, is Mobile: " + isMobile);
        if(isMobile) mobileUI.SetActive(true);
    }
}
