using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void LevelSelect() {
        LevelManager.Instance.LevelSelect();
    }

    public void StartTutorial() {
        LevelManager.Instance.JumpToLevel("TutorialLevel1");
    }
}
