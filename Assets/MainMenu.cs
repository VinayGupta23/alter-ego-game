using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LevelSelect() {
        SceneManager.LoadScene("LevelSelect");
    }

    public void Quit() {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
