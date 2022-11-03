using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuOverlay : MonoBehaviour
{
    private void Start()
    {

    }

    public void PauseTime()
    {
        Time.timeScale = 0f;
    }

    public void ResumeTime()
    {
        Time.timeScale = 1f;
    }

    public void Pause()
    {
        PauseTime();
        this.gameObject.SetActive(true);
    }

    public void Resume()
    {
        SFXManager.SFXInstance.Audio.PlayOneShot(SFXManager.SFXInstance.Click);
        ResumeTime();
        this.gameObject.SetActive(false);
    }

    public void TogglePause()
    {
        if (this.gameObject.activeSelf)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    public void LoadMenu()
    {
        LevelManager.Instance.MainMenu();
        SFXManager.SFXInstance.Audio.PlayOneShot(SFXManager.SFXInstance.Click);
        ResumeTime();
        
    }

    public void LoadLevelSelect()
    {
        LevelManager.Instance.LevelSelect();
        SFXManager.SFXInstance.Audio.PlayOneShot(SFXManager.SFXInstance.Click);
        ResumeTime();
        
    }
 }
