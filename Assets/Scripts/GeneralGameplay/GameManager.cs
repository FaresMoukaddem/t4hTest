using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public Timer timer;
    public SkeletonSpawner skeletonSpawner;
    public City city;
    public CannonControls cannonControls;
    public float winPopupDelay = 3.0f, lostPopupDelay = 5.0f;
    private BlackScreen blackScreen;

    private int score;

    private UIManager uI;

    // Start is called before the first frame update
    void Start()
    {
        uI = UIManager.Instance;
        blackScreen = uI.blackScreen;

        timer.UpdateTimerText();
        timer.OnTimerFinished.AddListener(OnTimerOver);

        city.OnCityDestroyed.AddListener(OnEntranceDestroyed);

        blackScreen.SetIsToggled(true);
        blackScreen.LerpScreenOut(() => 
        {
            uI.ShowTutorialMessage(() => 
            {
                StartGame();
            });
        });
    }

    void StartGame()
    {
        score = 0;
        timer.StartTimer();
        skeletonSpawner.ToggleSpawner(true);
        cannonControls.ToggleControls(true);
    }

    public int GetScore()
    {
        return score;
    }

    public void AddToScore(int amount = 1)
    {
        score++;
        if(uI != null)
        {
            uI.UpdateScoreText(score);
        }
    }

    private void OnTimerOver()
    {
        skeletonSpawner.StopSpawnerAndKillAll();
        cannonControls.ToggleControls(false);
        StartCoroutine(OnWinPopupCoroutine());
    }

    private void OnEntranceDestroyed()
    {
        timer.StopTimer();
        skeletonSpawner.ToggleSpawner(false);
        cannonControls.ToggleControls(false);
        skeletonSpawner.MakeEnemiesCelebrate();
        StartCoroutine(OnLostPopupCoroutine());
    }

    private IEnumerator OnLostPopupCoroutine()
    {
        yield return new WaitForSeconds(lostPopupDelay);

        uI.ShowLostMessage();
    }

    private IEnumerator OnWinPopupCoroutine()
    {
        yield return new WaitForSeconds(winPopupDelay);

        uI.ShowWinPopup();
    }
}
