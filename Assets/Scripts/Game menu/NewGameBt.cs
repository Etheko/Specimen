using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class NewGameBt1 : MonoBehaviour
{
    private Button button;

    public AudioSource audioSource;

    private GameObject audioSourceObject;

    void Start()
    {
        audioSourceObject = GameObject.Find("Audio Source");

        if (audioSourceObject != null)
        {
            audioSource = audioSourceObject.GetComponent<AudioSource>();
        }
        else
        {
            GameObject auxiliaryAudioSourceObject = GameObject.Find("Menu Aux Audio Source");

            if (auxiliaryAudioSourceObject != null)
            {
                audioSource = auxiliaryAudioSourceObject.GetComponent<AudioSource>();
            }

        }

        button = GetComponent<Button>();
        button.onClick.AddListener(NewGame);
    }

    void Update()
    {

    }

    IEnumerator FadeOut(AudioSource audioSource, float FadeTime)
    {
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / FadeTime;

            yield return null;
        }

        audioSource.Stop();
    }

    void NewGame()
    {
        // Load the game scene
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);

        // fade out music
        StartCoroutine(FadeOut(audioSource, 1f));

        // pause the music and set it to the beginning
        audioSource.Pause();
        audioSource.time = 0;

    }
}