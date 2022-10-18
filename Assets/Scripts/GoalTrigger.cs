using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalTrigger : MonoBehaviour
{
    private GameObject gem;

    private LevelHUD levelHUD;
    void Start()
    {
        

        gem = GameObject.FindWithTag("Gem");
        try
        {
            levelHUD = GameObject.Find("R&PButtons").GetComponent<LevelHUD>();
        }
        catch (NullReferenceException)
        {
            Debug.LogWarning("Did not find level HUD!");
        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Debug.Log("In Finish");
            // Debug.Log("Player Name: " + Analytics.Instance.GetPlayerName());
            // Debug.Log("Level: " + Analytics.Instance.GetLevel());
            // Debug.Log("Player Deaths: " + Analytics.Instance.GetPlayerDeaths());
            // Debug.Log("Clone Deaths: " + Analytics.Instance.GetCloneDeaths());


            GameProgress gameProgress = ProgressManager.Instance.GameProgress;
            string currentLevel = LevelManager.Instance.GetCurrentLevel();

            if (gem != null && gem.GetComponent<GemCollection>().IsCollected())
            {
                gameProgress.MarkComplete(currentLevel, true);
            }
            else
            {
                gameProgress.MarkComplete(currentLevel);
            }

            Analytics.Instance.Save();
            // StartCoroutine(Analytics.Post(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
            // Analytics.ResetSaveObject();

            if (levelHUD != null)
            {
                levelHUD.ShowLevelEnd();
            }
            else
            {
                LevelManager.Instance.NextLevel();
            }
        }
    }
}
