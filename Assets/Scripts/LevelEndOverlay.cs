using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelEndOverlay : MonoBehaviour
{
    // Start is called before the first frame update

    public static int NumLevelsCompleted = 1;
    
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            LoadNext();
        }
    }

    public void Display()
    {
        Time.timeScale = 0f;
        this.gameObject.SetActive(true);
    }

    public void LoadNext()
    {
        if ( LockSystem.lockMode){
            NumLevelsCompleted ++;
        }

        Time.timeScale = 1f;
        LevelManager.Instance.NextLevel();
    }

}
