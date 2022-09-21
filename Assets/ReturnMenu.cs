using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnMenu : MonoBehaviour
{
    public void return_to_menu() {
        SceneManager.LoadScene("MainMenu");
    }
}
