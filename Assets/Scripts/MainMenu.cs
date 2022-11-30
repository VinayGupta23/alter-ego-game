using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Start()
    {
        // Configure the Player GUID
        GameObject playerGUID = transform.Find("PlayerGUID").gameObject;
        TextMeshProUGUI playerGUIDText = playerGUID.GetComponent<TextMeshProUGUI>();
        SetGuidIfNotSet();
        playerGUIDText.text = PlayerPrefs.GetString("GUID");
    }
    
    private void SetGuidIfNotSet()
    {
        if (!PlayerPrefs.HasKey("GUID"))
        {
            PlayerPrefs.SetString("GUID", System.Guid.NewGuid().ToString());
        }
    }

    public void LevelSelect() {
        LevelManager.Instance.LevelSelect();
        SFXManager.SFXInstance.Audio.PlayOneShot(SFXManager.SFXInstance.Click);

    }

    public void StartTutorial() {
        LevelManager.Instance.JumpToLevel("0-1");
        SFXManager.SFXInstance.Audio.PlayOneShot(SFXManager.SFXInstance.Click);

    }
}
