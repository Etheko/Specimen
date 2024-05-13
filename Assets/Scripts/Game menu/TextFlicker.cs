using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextFlicker : MonoBehaviour
{
    private TMP_Text textMeshPro;
    private string[] texts = { "Specimen", "by Etheko.", "Specimen", "Will you?", "Could you?", "Specimen", "Am I alone?"}; // Array of strings

    private Coroutine changeTextCoroutine; // Coroutine to change the text

    // Start is called before the first frame update
    void Start()
    {
        textMeshPro = GetComponent<TMP_Text>();
        changeTextCoroutine = StartCoroutine(ChangeText());
    }

    void OnDisable()
    {
        StopCoroutine(changeTextCoroutine); // Stop the coroutine when the object is disabled
    }

    void OnEnable()
    {
        changeTextCoroutine = StartCoroutine(ChangeText()); // Start the coroutine when the object is enabled
    }

    // Coroutine to change the text every 5 seconds
    IEnumerator ChangeText()
    {
        while (true)
        {
            foreach (string text in texts)
            {
                // Delete each character of the previous text
                for (int i = textMeshPro.text.Length - 1; i >= 0; i--)
                {
                    textMeshPro.text = textMeshPro.text.Remove(i);
                    yield return new WaitForSeconds(0.1f);
                }

                // Type the characters of the following text
                for (int i = 0; i < text.Length; i++)
                {
                    textMeshPro.text = text.Substring(0, i) + "_";
                    yield return new WaitForSeconds(0.1f);
                }

                textMeshPro.text = text; // Remove the "_" at the end
                yield return new WaitForSeconds(5); // Wait for 5 seconds
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}