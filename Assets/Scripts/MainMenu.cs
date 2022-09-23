using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void LevelSelect() {
        GameObject.FindWithTag("LevelManager").GetComponent<LevelManager>().JumpToLevel("LevelSelect");
    }

    public void StartTutorial() {
        GameObject.FindWithTag("LevelManager").GetComponent<LevelManager>().JumpToLevel("TutorialLevel1");
    }
}
