using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalTrigger : MonoBehaviour
{
    private GameObject gem;

    private LevelHUD levelHUD;

    private  GameProgress gameProgress = ProgressManager.Instance.GameProgress;
    private string currentLevel = LevelManager.Instance.GetCurrentLevel();
    void Start()
    {
        

        gem = GameObject.Find("Gem");
        
        // When we add dependencies where gems are not present(only level based dependencies, we need to know whether there is a gem in the level
        // to compare. So recording the presence of gems.
        // This way we can even dependencies between levels with and without gems.
        if (gem != null) {
            gameProgress.FoundGem(currentLevel);
        }
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
