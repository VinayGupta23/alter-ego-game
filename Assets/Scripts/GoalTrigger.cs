using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalTrigger : MonoBehaviour
{
    private GameObject gem;
    private GameObject secret;

    private LevelHUD levelHUD;
    void Start()
    {
        gem = GameObject.FindWithTag("Gem");
        secret = GameObject.FindWithTag("SecretItem");

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
            GameProgress gameProgress = ProgressManager.Instance.GameProgress;
            string currentLevel = LevelManager.Instance.GetCurrentLevel();

            bool gotGem = false;
            bool gotSecret = false;
            if (gem != null && gem.GetComponent<GemCollection>().Collected)
            {
                gotGem = true;
            }
            if (secret != null && secret.GetComponent<SecretCollection>().Collected)
            {
                gotSecret = true;
            }
            gameProgress.MarkComplete(currentLevel, gotGem, gotSecret);

            Analytics.Instance.Save();
            SFXManager.SFXInstance.Audio.PlayOneShot(SFXManager.SFXInstance.Goal);

            if (levelHUD != null)
            {
                string reminder = "";
                if (gotSecret)
                {
                    if (gameProgress.Secrets() == Constants.TotalSecrets)
                    {
                        reminder = "All secrets found! Head over to level select to learn more.";
                    }
                }
                levelHUD.ShowLevelEnd(reminder);
            }
            else
            {
                LevelManager.Instance.NextLevel();
            }
        }
    }
}
