using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonFlicker : MonoBehaviour
{
    
    private Button button;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        
    }

    // Update is called once per frame
    void Update()
    {
        // Flicker the text by increasing and decreasing the alpha value
        
        ColorBlock cb = button.colors;
        cb.normalColor = new Color(cb.normalColor.r, cb.normalColor.g, cb.normalColor.b, Mathf.PingPong(Time.time, 1));
        
    }
}