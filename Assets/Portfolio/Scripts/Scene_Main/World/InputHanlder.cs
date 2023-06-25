using System.Collections;
using System.Collections.Generic;
using MalbersAnimations;
using UnityEngine;

public class InputHanlder : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SubToEvents();
    }

    private void SubToEvents()
    {
        SendLocation.OnLocationChange += (location) => EnableInput();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnableInput()
    {
        GetComponent<MalbersInput>().enabled = true;
    }
    
    private void DisableInput()
    {
        GetComponent<MalbersInput>().enabled = false;
    }
}
