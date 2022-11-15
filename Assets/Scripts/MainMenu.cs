using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    void Start()
    {
        // Configure the Player GUID
        GameObject playerGUID = transform.Find("PlayerGUID").gameObject;
        TextMeshProUGUI playerGUIDText = playerGUID.GetComponent<TextMeshProUGUI>();
        Analytics.Instance.SetGuidIfNotSet();
        playerGUIDText.text = PlayerPrefs.GetString("GUID");
    }

    public void LevelSelect() {
        LevelManager.Instance.LevelSelect();
    }

    public void StartTutorial() {
        LevelManager.Instance.JumpToLevel("0-1");
    }
}
