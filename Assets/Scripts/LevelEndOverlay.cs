using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelEndOverlay : MonoBehaviour
{
    // Start is called before the first frame update
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
        Time.timeScale = 1f;
        LevelManager.Instance.NextLevel();
    }
}
