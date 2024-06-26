using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonFlicker : MonoBehaviour
{

    private Button button;
    private ColorBlock cb;
    private TextMeshProUGUI buttonText; // Reference to the TextMeshProUGUI component

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        if (button == null) // If the object doesn't have a button component
        {
            return; // Exit the function
        }
        cb = button.colors;
        buttonText = button.GetComponentInChildren<TextMeshProUGUI>(); // Get the TextMeshProUGUI component
        button.colors = cb; // Apply the changes to the button

    }

    // Update is called once per frame
    void Update()
    {
        // Flicker the text by increasing and decreasing the alpha value

        float alpha = Random.Range(0.2f, 1.0f); // Generate a random alpha value
        // if it's not a button
        if (buttonText == null)
        {
            TMP_Text[] text = GetComponentsInChildren<TMP_Text>(); // Get the TextMeshProUGUI component
            for (int i = 0; i < text.Length; i++)
            {
                text[i].color = new Color(text[i].color.r, text[i].color.g, text[i].color.b, alpha); // Set the alpha value
            }
        }
        else
        {
            buttonText.color = new Color(buttonText.color.r, buttonText.color.g, buttonText.color.b, alpha); // Set the alpha value
            cb.normalColor = new Color(cb.normalColor.r, cb.normalColor.g, cb.normalColor.b, alpha); // Set the alpha value
        }

    }
}