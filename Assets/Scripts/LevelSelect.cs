using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    public void TUT1() {
        LevelManager.Instance.JumpToLevel("TutorialLevel1");
    }
    
    public void TUT2() {
        LevelManager.Instance.JumpToLevel("TutorialLevel2");
    }
    
    public void LVL1()
    {
        LevelManager.Instance.JumpToLevel("Level1");
    }
    
    public void TUT3() {
        LevelManager.Instance.JumpToLevel("TutorialLevel3");
    }

    public void LVL2() {
        LevelManager.Instance.JumpToLevel("Level2");
    }

    public void LVL3() {
        LevelManager.Instance.JumpToLevel("Level3");
    }
}
