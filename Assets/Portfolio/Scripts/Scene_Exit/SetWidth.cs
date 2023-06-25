using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetWidth : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        if (Camera.main!.aspect < 1)
        {
            RectTransform rt = GetComponent<RectTransform>();
            float canvasWidth = rt.rect.width;
            float desiredCanvasWidth = canvasWidth * Camera.main!.aspect;
            rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, desiredCanvasWidth);
            rt.localScale = rt.localScale * Camera.main!.aspect;
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
