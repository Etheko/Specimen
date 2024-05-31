using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoHighlightButton : MonoBehaviour
{

    public string buttonName; // name of the button object that should be highlighted when the current object is shown

    private GameObject lastButton; // name of the last button that was highlighted

    // Start is called before the first frame update
    void Start()
    {
        if (buttonName != null)
        {
            GameObject button = GameObject.Find(buttonName);
            if (button != null)
            {
                button.GetComponent<UnityEngine.UI.Button>().Select();
            }
        }

    }

    public void OnEnable()
    {
        if (lastButton != null)
        {
            if (GameObject.Find(lastButton.name) != null && GameObject.Find(lastButton.name).activeSelf)
            {
                lastButton = GameObject.Find(lastButton.name);
            }
            else
            {
                lastButton = null;
            }

            if (lastButton != null)
            {
                lastButton.GetComponent<UnityEngine.UI.Button>().Select();
            }
            else
            {
                if (GameObject.Find("Audio Settings") != null)
                {
                    lastButton = GameObject.Find("Audio Settings");
                    lastButton.GetComponent<UnityEngine.UI.Button>().Select();
                }
            }

        }
        else if (buttonName != null)
        {
            GameObject button = GameObject.Find(buttonName);
            if (button != null)
            {
                button.GetComponent<UnityEngine.UI.Button>().Select();
            }
        }
    }

    public void OnDisable()
    {
        if (UnityEngine.EventSystems.EventSystem.current != null)
            lastButton = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
