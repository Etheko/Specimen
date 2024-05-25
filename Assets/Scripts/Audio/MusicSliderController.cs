using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MusicSliderController : MonoBehaviour
{
    /* states of the slider:
     * 
     * [--------]
     * [#-------]
     * [##------]
     * [###-----]
     * [####----]
     * [#####---]
     * [######--]
     * [#######-]
     * [########]
     * 
     */


    private TMP_Text slider;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<TMP_Text>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float currentVolume = AudioSystemManager.instance.GetMusicVolume();
        int volume = (int)(currentVolume * 8);
        string sliderText = "[";
        for (int i = 0; i < volume; i++)
        {
            sliderText += "#";
        }
        for (int i = volume; i < 8; i++)
        {
            sliderText += "-";
        }
        sliderText += "]";
        slider.text = sliderText;
        
    }
}
