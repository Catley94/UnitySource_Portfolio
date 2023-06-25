using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using MalbersAnimations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplayDescription : MonoBehaviour
{
    [SerializeField] private SOProjectDescription soProjectDescription;
    private GameObject uiCanvas;
    private ProjectDescription UI_ProjectDescription;
    private OpenInteractionPrompt UI_OpenInteractPrompt;
    private CloseDescriptionPrompt UI_CloseDescriptionPrompt;
    private bool playerEntered = false;

    private void Start()
    {
        SetupReferences();
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerEntered)
        {
            ShowDescription();
        }
    }

    private void SetupReferences()
    {
        uiCanvas = GameObject.FindWithTag("UI");
        UI_ProjectDescription = uiCanvas.GetComponentInChildren<ProjectDescription>();
        UI_OpenInteractPrompt = uiCanvas.GetComponentInChildren<OpenInteractionPrompt>();
        UI_CloseDescriptionPrompt = uiCanvas.GetComponentInChildren<CloseDescriptionPrompt>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Animal"))
        {
            playerEntered = true;
            if(!UI_ProjectDescription.IsOpen()) ShowOpenTriggerPrompt();
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
        if(!UI_OpenInteractPrompt.IsOpen()) UI_OpenInteractPrompt.Show();
        UI_ProjectDescription.UpdateProjectText(soProjectDescription.description);
    }

    private void HideOpenTriggerPrompt()
    {
        if(UI_OpenInteractPrompt.IsOpen()) UI_OpenInteractPrompt.Hide();
    }
    
    private void ShowDescription()
    {
        if(!UI_ProjectDescription.IsOpen()) UI_ProjectDescription.Show();
        HideOpenTriggerPrompt();
        ShowCloseDescriptionPrompt();
        LockCursor.ShowCursor();
        DisableCharacterMovement();
        DisableCameraMovement();
        
    }

    private static void DisableCharacterMovement()
    {
        GameObject.FindWithTag("MainCamera").GetComponent<CinemachineBrain>().enabled = false;
    }

    private static void DisableCameraMovement()
    {
        GameObject.FindWithTag("Animal").GetComponent<MalbersInput>().enabled = false;
    }

    private void ShowCloseDescriptionPrompt()
    {
        if(!UI_CloseDescriptionPrompt.IsOpen()) UI_CloseDescriptionPrompt.Show();
    }
}
