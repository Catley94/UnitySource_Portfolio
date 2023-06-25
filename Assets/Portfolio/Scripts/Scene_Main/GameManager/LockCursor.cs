using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockCursor : MonoBehaviour
{

    [SerializeField] private IsMobileDevice isMobileDevice;
    
    // Start is called before the first frame update
    void Start()
    {
        SubToEvents();
        ShowCursor();
    }

    public static void HideCursor()
    {
        //Check if isMobile
        if (!IsMobileDevice.GetIsMobile())
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

    }


    private void SubToEvents()
    {
        SendLocation.OnLocationChange += (location) => HideCursor();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if(Cursor.lockState == CursorLockMode.Locked)
            {
                ShowCursor();
            }
            else
            {
                HideCursor();
            }
        }
    }

    public static void ShowCursor()
    {
        Cursor.lockState = CursorLockMode.None;
    }
}
