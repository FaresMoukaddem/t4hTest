using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class UIManager : Singleton<UIManager>
{
    public BlackScreen blackScreen;

    public TMP_Text scoreText;

    public MessagePopup messagePopup;

    public WinPopup winPopup;

    public string loseText;

    [TextAreaAttribute(5,15)]
    public string tutorialText;

    public void UpdateScoreText(int score)
    {
        scoreText.text = score.ToString();
    }

    public void ShowTutorialMessage(Action callback)
    {
        messagePopup.ShowMessage(tutorialText, "OK", () => 
        {
            messagePopup.HidePopup();
            callback?.Invoke();
        });
    }

    public void ShowLostMessage()
    {
        messagePopup.ShowMessage(loseText, "Restart", () => 
        {
            blackScreen.LerpScreenIn(() => 
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            });
        });
    }

    public void ShowWinPopup()
    {
        winPopup.ShowWinPopup();
    }
}
