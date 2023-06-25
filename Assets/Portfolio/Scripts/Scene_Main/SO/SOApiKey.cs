using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New_APIKey", menuName = "API_Key/New API Key", order = 1)]
public class SOApiKey : ScriptableObject
{
    public string APIKey = "";
}
