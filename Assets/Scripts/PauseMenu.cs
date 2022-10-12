using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    void Start()
    {
        GameObject levelName = transform.Find("LevelName").gameObject;
        TextMeshProUGUI levelNameText = levelName.GetComponent<TextMeshProUGUI>();
        levelNameText.text = SceneManager.GetActiveScene().name;

        GameObject GemNum = transform.Find("GemNum").gameObject;
        TextMeshProUGUI GemNumText = GemNum.GetComponent<TextMeshProUGUI>();
        // GemNumText.text = ProgressManager.Instance.GameProgress.Gems().ToString();
        GemNumText.text = Constants.TotalGems.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace)) 
        {
            if (GameIsPaused) 
            {
                Resume();
            } else 
            {
                Pause();
            }
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
           LevelManager.Instance.MainMenu(); 
        }
        
    }

    public void Resume() 
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMeanu()
    {
        LevelManager.Instance.MainMenu();
    }

    public void LevelSelectFromPause()
    {
        LevelManager.Instance.LevelSelect();
    }

    public void Move2NextLevel(){
        LevelManager.Instance.NextLevel();
        Time.timeScale = 1f;
    }
    

 }
