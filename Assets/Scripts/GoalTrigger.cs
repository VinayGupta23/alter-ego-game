using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalTrigger : MonoBehaviour
{
    private LevelManager levelManager;
    void Start()
    {
        levelManager = GameObject.FindWithTag("LevelManager").GetComponent<LevelManager>();
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            levelManager.NextLevel();
        }
    }
}
