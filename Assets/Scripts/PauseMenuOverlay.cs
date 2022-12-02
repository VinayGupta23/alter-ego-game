using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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
        SetFirstSelected();
    }

    public void Resume()
    {
        SFXManager.SFXInstance.Audio.PlayOneShot(SFXManager.SFXInstance.Click);
        ResumeTime();
        this.gameObject.SetActive(false);
        ResetFirstSelected();
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

    private void SetFirstSelected()
    {
        EventSystem.current.SetSelectedGameObject(this.gameObject.transform.Find("Resume").gameObject, null);
    }

    private void ResetFirstSelected()
    {
        EventSystem.current.SetSelectedGameObject(null, null);
    }
 }
