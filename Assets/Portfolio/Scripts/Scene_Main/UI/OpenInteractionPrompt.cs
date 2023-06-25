using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenInteractionPrompt : MonoBehaviour
{
    [SerializeField] private GameObject container; 
    
    public void Show()
    {
        container.SetActive(true);
    }
    
    public void Hide()
    {
        container.SetActive(false);
    }

    public bool IsOpen()
    {
        return container.activeInHierarchy;
    }
}
