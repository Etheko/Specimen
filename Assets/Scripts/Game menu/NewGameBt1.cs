using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NewGameBt1 : ButtonFlicker
{
    private Button button;
    private ColorBlock cb;
    private TextMeshProUGUI buttonText; // Reference to the TextMeshProUGUI component

    void Start()
    {
        button = GetComponent<Button>();
        cb = button.colors;
        buttonText = button.GetComponentInChildren<TextMeshProUGUI>(); // Get the TextMeshProUGUI component
        button.colors = cb; // Apply the changes to the button
    }

    void Update()
    {
        float alpha = Random.Range(0.2f, 1.0f); // Generate a random alpha value
        buttonText.color = new Color(buttonText.color.r, buttonText.color.g, buttonText.color.b, alpha); // Set the alpha value
        cb.normalColor = new Color(cb.normalColor.r, cb.normalColor.g, cb.normalColor.b, alpha); // Set the alpha value
    }
}