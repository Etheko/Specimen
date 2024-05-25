using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroMainController : MonoBehaviour
{
    // Start is called before the first frame update
    public float delay;

    void Start()
    {
        StartCoroutine(StartMusic());
    }

    IEnumerator StartMusic()
    {
        yield return new WaitForSeconds(delay);
        AudioSystemManager.instance.ForcePlayMusic("intro2");
    }
}
