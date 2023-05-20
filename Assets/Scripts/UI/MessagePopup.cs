using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class MessagePopup : GenericPopup
{
    public TMP_Text bodyText;

    public Button button;

    public void ShowMessage(string body, string buttonText = "ok", Action buttonAction = null, Action OnShowCallback = null)
    {
        bodyText.text = body;
        button.GetComponentInChildren<TMP_Text>().text = buttonText;
        
        button.onClick.RemoveAllListeners();
        if(buttonAction == null)
        {
            button.onClick.AddListener(DefaultButtonAction);
        }
        else
        {
            button.onClick.AddListener(() =>
            {
                button.interactable = false;
                buttonAction();
            });
        }

        button.interactable = false;
        ShowPopup(() => 
        {
            button.interactable = true;
            OnShowCallback?.Invoke();
        });
    }

    private void DefaultButtonAction()
    {
        button.interactable = false;
        HidePopup();
    }
}
