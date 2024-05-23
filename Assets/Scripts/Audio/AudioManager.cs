using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioSource audioSource;

    public float delay;

    void Start()
    {

        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }

        //wait a few miliseconds before starting the music
        StartCoroutine(StartMusic());
        DontDestroyOnLoad(gameObject);
    }

    IEnumerator StartMusic()
    {
        yield return new WaitForSeconds(delay);
        audioSource.Play();
    }

    // fade out the audio when the scene is changed
    public void FadeOut()
    {
        StartCoroutine(FadeOutAudio(1.0f));
    }

    public IEnumerator FadeOutAudio(float fadeTime)
    {
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / fadeTime;
            yield return null;
        }

        Destroy(gameObject);
    }


}
