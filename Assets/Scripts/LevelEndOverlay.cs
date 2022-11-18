using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelEndOverlay : MonoBehaviour
{
    public bool isOrphanLevel = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Return) | Input.GetKey(KeyCode.Space))
        {
            LoadNext();
        }
    }

    public void Display()
    {
        Time.timeScale = 0f;
        this.gameObject.SetActive(true);
    }

    public void LoadNext()
    {
        Time.timeScale = 1f;
        if (isOrphanLevel)
        {
            LevelManager.Instance.LevelSelect();
        }
        else
        {
            LevelManager.Instance.NextLevel();
        }
    }
    
    public void LoadLevelSelect()
    {
        Time.timeScale = 1f;
        LevelManager.Instance.LevelSelect();
    }
}
