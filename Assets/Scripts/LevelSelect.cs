using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    public void LV1()
    {
        GameObject.FindWithTag("LevelManager").GetComponent<LevelManager>().JumpToLevel("Level1");
    }

    public void LV2() {
        GameObject.FindWithTag("LevelManager").GetComponent<LevelManager>().JumpToLevel("Level2");
    }

    public void LV3() {
        GameObject.FindWithTag("LevelManager").GetComponent<LevelManager>().JumpToLevel("Level3");
    }

    public void LV4() {
        GameObject.FindWithTag("LevelManager").GetComponent<LevelManager>().JumpToLevel("Level4");
    }

    public void LV5() {
        GameObject.FindWithTag("LevelManager").GetComponent<LevelManager>().JumpToLevel("Level5");
    }
}
