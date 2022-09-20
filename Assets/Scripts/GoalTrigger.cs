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
            int current = SceneManager.GetActiveScene().buildIndex + 1;
            Debug.Log(current);
            if (SceneManager.GetSceneByBuildIndex(current).IsValid())
            {
                
                SceneManager.LoadScene(current);
            }
        }
    }
}
