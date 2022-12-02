using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelHUD : MonoBehaviour
{
    public GameObject levelEndUI;
    public GameObject pauseMenuUI;

    private PauseMenuOverlay pauseMenuComponent;
    private LevelEndOverlay levelEndComponent;

    public bool IsPaused
    {
        get
        {
            if (pauseMenuComponent == null)
            {
                return false;
            }
            return pauseMenuUI.activeSelf;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Configure the level name
        GameObject levelName = transform.Find("LevelName").gameObject;
        TextMeshProUGUI levelNameText = levelName.GetComponent<TextMeshProUGUI>();
        levelNameText.text = SceneManager.GetActiveScene().name;

        // Configure components
        pauseMenuComponent = pauseMenuUI.GetComponent<PauseMenuOverlay>();
        levelEndComponent = levelEndUI.GetComponent<LevelEndOverlay>();
    }

    // Update is called once per frame
    void Update()
    {
        if (levelEndUI.activeSelf)
        {
            // Stop handling input if level is completed
            return;
        }

        if (Input.GetKeyDown(KeyCode.R) && pauseMenuUI.activeSelf == false)
        {
            // Don't allow restart when pause menu is open
            Restart();
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        pauseMenuComponent.TogglePause();
        SFXManager.SFXInstance.Audio.PlayOneShot(SFXManager.SFXInstance.Click);
    }

    public void Restart()
    {
        Analytics.Instance.RecordLevelRestart();
        Debug.Log("About to save from Restart");
        Analytics.Instance.Save();
        LevelManager.Instance.RestartLevel();
        SFXManager.SFXInstance.Audio.PlayOneShot(SFXManager.SFXInstance.Click);
    }

    public void ShowLevelEnd(string reminder = "")
    {
        levelEndComponent.SetReminder(reminder);
        levelEndComponent.Display();
    }
}
