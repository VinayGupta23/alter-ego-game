using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public void LevelSelect() {
        LevelManager.Instance.LevelSelect();
        SFXManager.SFXInstance.Audio.PlayOneShot(SFXManager.SFXInstance.Click);

    }

    public void StartTutorial() {
        LevelManager.Instance.JumpToLevel("0-1");
        SFXManager.SFXInstance.Audio.PlayOneShot(SFXManager.SFXInstance.Click);

    }
}
