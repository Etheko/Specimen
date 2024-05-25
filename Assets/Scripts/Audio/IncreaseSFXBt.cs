using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IncreaseSFXBt : MonoBehaviour
{
    Button button;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(IncreaseSFX);
    }

    void IncreaseSFX()
    {
        AudioSystemManager.instance.RaiseEffectsVolume();
        AudioSystemManager.instance.PlayEffect("sfxAction");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
