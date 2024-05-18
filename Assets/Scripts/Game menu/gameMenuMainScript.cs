using UnityEngine;

public class gameMenuMainScript : MonoBehaviour
{
    public AudioSource audioSource;

    private GameObject audioSourceObject;

    // Start is called before the first frame update
    void Start()
    {
        audioSourceObject = GameObject.Find("Audio Source");

        if (audioSourceObject == null)
        {
            audioSourceObject = GameObject.Find("Menu Aux Audio Source");

            AudioSource auxiliaryAudioSource = GameObject.Find("Menu Aux Audio Source").GetComponent<AudioSource>();

            if (auxiliaryAudioSource != null && !auxiliaryAudioSource.isPlaying)
            {
                auxiliaryAudioSource.Play();
            }

        }
        else
        {
            audioSource = audioSourceObject.GetComponent<AudioSource>();
            //check if it is paused
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
