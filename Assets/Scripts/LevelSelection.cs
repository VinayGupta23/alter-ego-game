using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    private Toggle toggle;
    private string level;
    // Start is called before the first frame update
    void Start()
    {
        TextMeshProUGUI tmpText = GetComponentInChildren<TextMeshProUGUI>();
        level = tmpText.text;
        
        try
        {
            GameObject go = transform.Find("Toggle").gameObject;
            toggle = go.GetComponent<Toggle>();
        }
        catch (NullReferenceException)
        {
            Debug.LogWarning("Check icon is missing for level " + level + "!");
        }
    }

    public void OpenScene(){
        LevelManager.Instance.JumpToLevel(level);
    }

    void Update() 
    {
        if (toggle == null)
        {
            return;
        }

        toggle.isOn = false;
        if (ProgressManager.Instance.GameProgress.IsCompleted(level)) {
            // Debug.Log("iscompleted ");
            // make toggle on 
            toggle.isOn = true;
        }
    }
}

