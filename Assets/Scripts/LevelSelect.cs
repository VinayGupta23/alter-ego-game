using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    public void TUT1() {
        GameObject.FindWithTag("LevelManager").GetComponent<LevelManager>().JumpToLevel("TutorialLevel1");
    }
    
    public void TUT2() {
        GameObject.FindWithTag("LevelManager").GetComponent<LevelManager>().JumpToLevel("TutorialLevel2");
    }
    
    public void LVL1()
    {
        GameObject.FindWithTag("LevelManager").GetComponent<LevelManager>().JumpToLevel("Level1");
    }
    
    public void TUT3() {
        GameObject.FindWithTag("LevelManager").GetComponent<LevelManager>().JumpToLevel("TutorialLevel3");
    }

    public void LVL2() {
        GameObject.FindWithTag("LevelManager").GetComponent<LevelManager>().JumpToLevel("Level2");
    }

    public void LVL3() {
        GameObject.FindWithTag("LevelManager").GetComponent<LevelManager>().JumpToLevel("Level3");
    }
}
