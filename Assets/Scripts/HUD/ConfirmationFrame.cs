using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmationFrame : MonoBehaviour
{
    private IConfirmAction confirmAction;

    private GameObject message;

    private LanguageManager languageManager;

    private void Start()
    {
        languageManager = GetComponent<LanguageManager>();
        message = transform.Find("Text").gameObject;
    }

    public void Show(IConfirmAction confirmAction, string messageKey)
    {
        if (languageManager == null)
            languageManager = GetComponent<LanguageManager>();
        if (message == null)
            message = transform.Find("Text").gameObject;
        this.confirmAction = confirmAction;
        message.GetComponent<TMPro.TextMeshProUGUI>().text = languageManager.getText(messageKey);
        gameObject.SetActive(true);
    }

    public void OnConfirmButtonPressed()
    {
        AudioSystemManager.instance.PlayEffect("sfxAction");
        confirmAction.Execute();
    }

    public void OnCancelButtonPressed()
    {
        AudioSystemManager.instance.PlayEffect("sfxCancel");
        confirmAction.Cancel();
    }

}
