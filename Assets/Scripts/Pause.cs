using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject pauseMenuUI;

    public void PauseGame()
    {
        if (pauseMenuUI != null) 
        {
            bool isActive = pauseMenuUI.activeSelf;
            pauseMenuUI.SetActive(!isActive);
        }
    }
}
