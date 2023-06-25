using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClipboardMessage : MonoBehaviour
{
    private GameObject uiClipboardMessage;
    private bool isBackgroundHidden;
    private bool isTextHidden;

    private void Start()
    {
        uiClipboardMessage = gameObject.transform.GetChild(0).gameObject;
    }

    public void Show()
    {
        if (!uiClipboardMessage.activeInHierarchy)
        {
            uiClipboardMessage.SetActive(true);
            Invoke(nameof(Hide), 3f);
        }
    }

    private void Hide()
    {
        isBackgroundHidden = false;
        isTextHidden = false;
        StartCoroutine(FadeOutBackground());
        StartCoroutine(FadeOutText());
    }

    private IEnumerator FadeOutBackground()
    {
        Image background = uiClipboardMessage.GetComponentInChildren<Image>();
        Color originalColor = background.color;
        float timer = 0f;

        while (background.color.a > 0)
        {
            timer += Time.deltaTime;
            float normalizedTime = timer / 1f; // 1f is the duration of the fade
            background.color = Color.Lerp(originalColor, new Color(originalColor.r, originalColor.g, originalColor.b, 0f), normalizedTime);

            yield return null;
        }

        isBackgroundHidden = true;
        CheckFadeCompletion();
    }

    private IEnumerator FadeOutText()
    {
        TMP_Text text = uiClipboardMessage.GetComponentInChildren<TMP_Text>();
        Color originalColor = text.color;
        float timer = 0f;

        while (text.color.a > 0)
        {
            timer += Time.deltaTime;
            float normalizedTime = timer / 1f; // 1f is the duration of the fade
            text.color = Color.Lerp(originalColor, new Color(originalColor.r, originalColor.g, originalColor.b, 0f), normalizedTime);

            yield return null;
        }

        isTextHidden = true;
        CheckFadeCompletion();
    }

    private void CheckFadeCompletion()
    {
        if (isBackgroundHidden && isTextHidden)
        {
            uiClipboardMessage.SetActive(false);
            ResetBackgroundAlpha();
            ResetTextAlpha();
        }
    }

    private void ResetBackgroundAlpha()
    {
        Image background = uiClipboardMessage.GetComponentInChildren<Image>();
        Color originalColor = background.color;
        background.color = new Color(originalColor.r, originalColor.g, originalColor.b, 1f);
    }
    
    private void ResetTextAlpha()
    {
        TMP_Text text = uiClipboardMessage.GetComponentInChildren<TMP_Text>();
        Color originalColor = text.color;
        text.color = new Color(originalColor.r, originalColor.g, originalColor.b, 1f);
    }
}
