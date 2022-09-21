using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalTrigger : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            /*int current = SceneManager.GetActiveScene().buildIndex + 1;
            if (SceneManager.GetSceneByBuildIndex(current).IsValid())
            {
                SceneManager.LoadScene(current, LoadSceneMode.Single);
            }*/
            SceneManager.LoadScene("Level2", LoadSceneMode.Single);
        }
    }
}
