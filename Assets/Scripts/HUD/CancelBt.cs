using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CancelBt : MonoBehaviour
{
    private Button button;
    private GameObject audioSourceObject;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(CancelDialog);
        
    }

    void CancelDialog()
    {
        AudioSystemManager.instance.PlayEffect("sfxAction");
        // Close the dialog (parent)
        gameObject.transform.parent.gameObject.SetActive(false);
    }
}
