using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    private string level;
    private Button button;
    private Toggle toggle;

    // Start is called before the first frame update
    void Start()
    {
        TextMeshProUGUI tmpText = GetComponentInChildren<TextMeshProUGUI>();
        level = tmpText.text;

        button = GetComponent<Button>();
        button.interactable = LevelDependency.Instance.DMInstance.IsLocked(level);

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
