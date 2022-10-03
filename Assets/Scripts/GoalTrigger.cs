using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalTrigger : MonoBehaviour
{

    public GameObject LevelEndPopUp;

    void Start()
    {

    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("In Finish");
            Debug.Log("Player Name: " + Analytics.Instance.GetPlayerName());
            Debug.Log("Level: " + Analytics.Instance.GetLevel());
            Debug.Log("Player Deaths: " + Analytics.Instance.GetPlayerDeaths());
            Debug.Log("Clone Deaths: " + Analytics.Instance.GetCloneDeaths());

            Analytics.Instance.Save();
            // StartCoroutine(Analytics.Post(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
            // Analytics.ResetSaveObject();

            LevelEndPopUp.SetActive(true);

            // LevelManager.Instance.NextLevel();
        }
    }

    public void Move2NextLevel(){
        LevelManager.Instance.NextLevel();
    }

    

}
