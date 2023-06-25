using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SendLocation : MonoBehaviour
{
    
    public static event Action<string> OnLocationChange;
    [SerializeField] private TMP_InputField inputField;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SendLocationToClient();
        }
    }

    public void SendLocationToClient()
    {
        OnLocationChange?.Invoke(inputField.text);
        gameObject.SetActive(false);
    }
}
