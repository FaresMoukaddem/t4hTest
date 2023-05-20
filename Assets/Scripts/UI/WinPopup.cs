using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinPopup : GenericPopup
{
    public NumberTextLerper lerper;

    public Button button;

    public void ShowWinPopup()
    {
        lerper.SetTextValue(0);
        button.interactable = false;

        SetupButtonAction();

        ShowPopup(() => 
        {
            lerper.StartLerping(0, GameManager.Instance.GetScore(), (g) => 
            {
                button.interactable = true;
            });
        });
    }

    private void SetupButtonAction()
    {
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(OnButtonClicked);
    }

    private void OnButtonClicked()
    {
        button.interactable = false;
        UIManager.Instance.blackScreen.LerpScreenIn(() => 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        });
    }
}
