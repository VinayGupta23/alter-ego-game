using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quit : MonoBehaviour
{
    public void LevelSelect() {
        SceneManager.LoadScene("LevelSelect");
    }

    public Quit() {
        Application.Quit();
        
    }
}
