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
}
