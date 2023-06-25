using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToExitScene : MonoBehaviour
{
    
    private GameObject uiCanvas;
    private MoveToExitScenePrompt UI_MoveToExitScenePrompt;
    private bool playerEntered = false;
    
    // Start is called before the first frame update
    void Start()
    {
        SetupReferences();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerEntered)
        {
            //TODO: Move to new scene
            MoveToExit();
        }
    }

    public void MoveToExit()
    {
        SceneManager.LoadScene("Exit");
    }

    private void SetupReferences()
    {
        uiCanvas = GameObject.FindWithTag("UI");
        UI_MoveToExitScenePrompt = uiCanvas.GetComponentInChildren<MoveToExitScenePrompt>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Animal"))
        {
            playerEntered = true;
            ShowOpenTriggerPrompt();
            LockCursor.ShowCursor();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Animal"))
        {
            playerEntered = false;
            HideOpenTriggerPrompt();
            LockCursor.HideCursor();
        }
    }
    
    private void ShowOpenTriggerPrompt()
    {
        if(!UI_MoveToExitScenePrompt.IsOpen()) UI_MoveToExitScenePrompt.Show();
    }
    
    private void HideOpenTriggerPrompt()
    {
        if(UI_MoveToExitScenePrompt.IsOpen()) UI_MoveToExitScenePrompt.Hide();
    }
    
    
}
