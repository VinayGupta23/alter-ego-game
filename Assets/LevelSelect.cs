using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public void LV1() {
        SceneManager.LoadScene("Level1");
    }

    public void LV2() {
        SceneManager.LoadScene("Level2");
    }
}
