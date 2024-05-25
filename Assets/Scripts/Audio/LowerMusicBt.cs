using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LowerMusicBt : MonoBehaviour
{
    private Button button;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(LowerMusic);

    }

    void LowerMusic()
    {
        AudioSystemManager.instance.LowerMusicVolume();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
