using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSystemManager : MonoBehaviour
{
    private GameObject audioSystem;
    public static AudioSystemManager instance;

    private GameObject musicController;
    private GameObject effectsController;

    // Start is called before the first frame update
    void Awake()
    {
        // check if there is already an instance of the audio system script
        if (instance == null)
        {
            Debug.Log("NO AUDIO SYSTEM INSTANCE: Creating new instance of the audio system");
            // if there is no instance, use the current object
            instance = this;
            audioSystem = instance.gameObject;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            Debug.Log("AUDIO SYSTEM INSTANCE FOUND: Using existing instance of the audio system");
            // if there is an instance, use the existing object
            audioSystem = instance.gameObject;
        }

        musicController = audioSystem.transform.Find("Music").gameObject;
        effectsController = audioSystem.transform.Find("Effects").gameObject;

        // get the values for the music and effects volumes from PlayerPrefs
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            musicController.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("musicVolume");
        }
        else
        {
            musicController.GetComponent<AudioSource>().volume = 0.5f;
        }

        if (PlayerPrefs.HasKey("effectsVolume"))
        {
            effectsController.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("effectsVolume");
        }
        else
        {
            effectsController.GetComponent<AudioSource>().volume = 0.5f;
        }
    }
    /// <summary>
    /// Returns the name of the music that is currently being played
    /// </summary>
    /// <returns></returns>
    public string getWhatsBeingPlayedMusic()
    {
        return musicController.GetComponent<AudioSource>().clip.name;
    }

    /// <summary>
    /// Returns the name of the effect that is currently being played
    /// </summary>
    /// <returns></returns>
    public string getWhatsBeingPlayedEffect()
    {
        return effectsController.GetComponent<AudioSource>().clip.name;
    }

    /// <summary>
    /// Returns true if music is currently playing
    /// </summary>
    /// <returns></returns>
    public bool isMusicPlaying()
    {
        return musicController.GetComponent<AudioSource>().isPlaying;
    }

    /// <summary>
    /// Returns true if effect is currently playing
    /// </summary>
    /// <returns></returns>
    public bool isEffectPlaying()
    {
        return effectsController.GetComponent<AudioSource>().isPlaying;
    }

    /// <summary>
    /// Force plays the specified music file even if it is already playing
    /// </summary>
    /// <param name="filename"></param>
    public void ForcePlayMusic(string filename)
    {
        musicController.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Audio/Music/" + filename);
        musicController.GetComponent<AudioSource>().Play();
    }

    /// <summary>
    /// Plays the specified music file unless it is already playing
    /// </summary>
    /// <param name="fileName"></param>
    public void PlayMusic(string fileName)
    {
        //check if what's requested is already playing
        if (musicController.GetComponent<AudioSource>().clip != null && musicController.GetComponent<AudioSource>().clip.name == fileName && musicController.GetComponent<AudioSource>().isPlaying)
        {
            return;
        }
        musicController.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Audio/Music/" + fileName);
        musicController.GetComponent<AudioSource>().Play();

    }

    /// <summary>
    /// Plays the specified music file on loop
    /// </summary>
    /// <param name="filename"></param>
    public void PlayMusicOnLoop(string filename)
    {
        if (musicController.GetComponent<AudioSource>().clip != null && musicController.GetComponent<AudioSource>().clip.name == filename && musicController.GetComponent<AudioSource>().isPlaying)
        {
            return;
        }
        musicController.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Audio/Music/" + filename);
        musicController.GetComponent<AudioSource>().loop = true;
        musicController.GetComponent<AudioSource>().Play();
    }


    /// <summary>
    /// Plays the specified effect file
    /// </summary>
    /// <param name="fileName"></param>
    public void PlayEffect(string fileName)
    {
        effectsController.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Audio/Sounds/" + fileName);
        effectsController.GetComponent<AudioSource>().Play();
    }

    /// <summary>
    /// Stops the music that is currently playing
    /// </summary>
    public void StopMusic()
    {
        musicController.GetComponent<AudioSource>().Stop();
    }

    /// <summary>
    /// Stops the effect that is currently playing
    /// </summary>
    public void StopEffect()
    {
        effectsController.GetComponent<AudioSource>().Stop();
    }

    /// <summary>
    /// Pauses the music that is currently playing
    /// </summary>
    public void PauseMusic()
    {
        musicController.GetComponent<AudioSource>().Pause();
    }

    /// <summary>
    /// Pauses the effect that is currently playing
    /// </summary>
    public void PauseEffect()
    {
        effectsController.GetComponent<AudioSource>().Pause();
    }

    /// <summary>
    /// Resumes the music that is currently paused
    /// </summary>
    public void UnPauseMusic()
    {
        musicController.GetComponent<AudioSource>().UnPause();
    }

    /// <summary>
    /// Resumes the effect that is currently paused
    /// </summary>
    public void UnPauseEffect()
    {
        effectsController.GetComponent<AudioSource>().UnPause();
    }

    /// <summary>
    /// Sets the volume of the music
    /// </summary>
    /// <param name="volume"></param>
    public void SetMusicVolume(float volume)
    {
        musicController.GetComponent<AudioSource>().volume = volume;
        PlayerPrefs.SetFloat("musicVolume", volume);
    }

    /// <summary>
    /// Sets the volume of the effects
    /// </summary>
    /// <param name="volume"></param>
    public void SetEffectsVolume(float volume)
    {
        effectsController.GetComponent<AudioSource>().volume = volume;
        PlayerPrefs.SetFloat("effectsVolume", volume);
    }

    /// <summary>
    /// Returns the volume of the music
    /// </summary>
    /// <returns></returns>
    public float GetMusicVolume()
    {
        return musicController.GetComponent<AudioSource>().volume;
    }

    /// <summary>
    /// Returns the volume of the effects
    /// </summary>
    /// <returns></returns>
    public float GetEffectsVolume()
    {
        return effectsController.GetComponent<AudioSource>().volume;
    }

    /// <summary>
    /// Lower the volume of the music
    /// </summary>
    public void LowerMusicVolume() //there are 8 levels of volume (from 0 to 1), so we decrease the volume by 0.125
    {
        if (musicController.GetComponent<AudioSource>().volume > 0)
        {
            musicController.GetComponent<AudioSource>().volume -= 0.125f;
        }
        PlayerPrefs.SetFloat("musicVolume", musicController.GetComponent<AudioSource>().volume);
    }

    /// <summary>
    /// Raise the volume of the music
    /// </summary>
    public void RaiseMusicVolume() //there are 8 levels of volume (from 0 to 1), so we increase the volume by 0.125
    {
        if (musicController.GetComponent<AudioSource>().volume < 1)
        {
            musicController.GetComponent<AudioSource>().volume += 0.125f;
        }
        PlayerPrefs.SetFloat("musicVolume", musicController.GetComponent<AudioSource>().volume);
    }

    /// <summary>
    /// Lower the volume of the effects
    /// </summary>
    public void LowerEffectsVolume() //there are 8 levels of volume (from 0 to 1), so we decrease the volume by 0.125
    {
        if (effectsController.GetComponent<AudioSource>().volume > 0)
        {
            effectsController.GetComponent<AudioSource>().volume -= 0.125f;
        }
        PlayerPrefs.SetFloat("effectsVolume", effectsController.GetComponent<AudioSource>().volume);
    }

    /// <summary>
    /// Raise the volume of the effects
    /// </summary>
    public void RaiseEffectsVolume() //there are 8 levels of volume (from 0 to 1), so we increase the volume by 0.125
    {
        if (effectsController.GetComponent<AudioSource>().volume < 1)
        {
            effectsController.GetComponent<AudioSource>().volume += 0.125f;
        }
        PlayerPrefs.SetFloat("effectsVolume", effectsController.GetComponent<AudioSource>().volume);
    }

    public IEnumerator FadeOutAudio(AudioSource audioSource, float fadeTime)
    {
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / fadeTime;
            yield return null;
        }

        audioSource.Stop();
        audioSource.volume = startVolume;
    }

    public IEnumerator FadeInAudio(AudioSource audioSource, float fadeTime, string fileName)
    {
        musicController.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Audio/Music/" + fileName);
        float startVolume = audioSource.volume;
        audioSource.volume = 0;
        audioSource.Play();

        while (audioSource.volume < startVolume)
        {
            audioSource.volume += startVolume * Time.deltaTime / fadeTime;
            yield return null;
        }
    }

    /// <summary>
    /// Fade in the music
    /// </summary>
    public void fadeInMusic(string fileName)
    {
        StartCoroutine(FadeInAudio(musicController.GetComponent<AudioSource>(), 1.0f, fileName));
    }

    /// <summary>
    /// Fade out the music
    /// </summary>
    public void fadeOutMusic()
    {

        StartCoroutine(FadeOutAudio(musicController.GetComponent<AudioSource>(), 1.0f));
    }

    /// <summary>
    /// Enables the low pass filter on the music
    /// </summary>
    public void enableFilter()
    {
        musicController.GetComponent<AudioLowPassFilter>().enabled = true;
    }

    /// <summary>
    /// Disables the low pass filter on the music
    /// </summary>
    public void disableFilter()
    {
        musicController.GetComponent<AudioLowPassFilter>().enabled = false;
    }


    // Update is called once per frame
    void Update()
    {

    }
}
