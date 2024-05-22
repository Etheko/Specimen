using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInOutEffect : MonoBehaviour
{

    public CanvasGroup canvasGroup;
    public bool fadeIn = false;
    public bool fadeOut = false;

    public float fadeSpeed;

    // Update is called once per frame
    void Update()
    {
        if(fadeIn)
        {
            if(canvasGroup.alpha < 1)
            {
                canvasGroup.alpha += fadeSpeed * Time.deltaTime;
                if(canvasGroup.alpha >= 1)
                {
                    fadeIn = false;
                }
            }
            
        }

        if(fadeOut)
        {
            if(canvasGroup.alpha > 0)
            {
                canvasGroup.alpha -= fadeSpeed * Time.deltaTime;
                if(canvasGroup.alpha == 0)
                {
                    fadeOut = false;
                }
            }
        }
    }

    public void FadeIn()
    {
        fadeIn = true;
    }

    public void FadeOut()
    {
        fadeOut = true;
    }
}
