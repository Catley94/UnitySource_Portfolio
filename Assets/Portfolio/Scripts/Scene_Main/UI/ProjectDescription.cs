using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using MalbersAnimations;
using UnityEngine;
using UnityEngine.UI;

public class ProjectDescription : MonoBehaviour
{
    
    [SerializeField] private GameObject container;
    private CloseDescriptionPrompt UI_CloseDescriptionPrompt;
    [SerializeField] private Scrollbar scrollbar;

    private void Start()
    {
        SetupReferences();
    }

    private void SetupReferences()
    {
        UI_CloseDescriptionPrompt = GameObject.FindWithTag("UI").GetComponentInChildren<CloseDescriptionPrompt>();
    }

    public void Show()
    {
        container.SetActive(true);
    }
    
    public void Hide()
    {
        container.SetActive(false);
    }

    public void UpdateProjectText(string text)
    {
        container.GetComponentInChildren<TMPro.TMP_Text>().text = text;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ResetScrollBarPosition();
            Hide();
            HideCloseDescriptionPrompt();
            LockCursor.HideCursor();
            EnableCameraMovement();
            EnableCharacterMovement();
        }
    }

    private static void EnableCharacterMovement()
    {
        GameObject.FindWithTag("Animal").GetComponent<MalbersInput>().enabled = true;
    }

    private static void EnableCameraMovement()
    {
        GameObject.FindWithTag("MainCamera").GetComponent<CinemachineBrain>().enabled = true;
    }

    private void ResetScrollBarPosition()
    {
        scrollbar.value = 1f;
    }

    public bool IsOpen()
    {
        return container.activeInHierarchy;
    }
    
    private void HideCloseDescriptionPrompt()
    {
        if(UI_CloseDescriptionPrompt.IsOpen()) UI_CloseDescriptionPrompt.Hide();
    }
}
