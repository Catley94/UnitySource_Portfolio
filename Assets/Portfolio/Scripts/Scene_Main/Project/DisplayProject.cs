using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using UnityEngine;

public class DisplayProject : MonoBehaviour
{
    [SerializeField] private string link;
    private GameObject UI;
    private bool playerHasEntered = false;

    private void Start()
    {
        UI = GameObject.Find("UI");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Animal"))
        {
            if (!playerHasEntered)
            {
                // Debug.Log($"ENTERED PROJECT: {gameObject.name}");
                playerHasEntered = true;
                //TODO: Display UI to say link has been copied into Clipboard
                UI.GetComponent<ClipboardMessage>().Show();
                //TODO: Copy Link to Clipboard
                Bridge.SendToClipboard(link);
                #if UNITY_EDITOR
                    GUIUtility.systemCopyBuffer = link; //For Development Purposes
                #endif
            }
        }
    }
//TODO: https://www.youtube.com/watch?v=gXx_j-6z8jY
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Animal") && playerHasEntered)
        {
            // Debug.Log($"EXITED PROJECT: {gameObject.name}");
            playerHasEntered = false;
        }

        
    }
}
