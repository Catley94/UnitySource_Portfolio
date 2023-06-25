using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Project Description", menuName = "Projects/New Project Description", order = 1)]
public class SOProjectDescription : ScriptableObject
{
    public Sprite image;
    [TextArea(10, 100)] public string description;
}
