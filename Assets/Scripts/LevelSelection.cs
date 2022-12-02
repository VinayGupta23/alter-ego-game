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
    private Image buttonImage;
    private GameObject completionTick;
    private AlertManager alertManager;

    // Start is called before the first frame update
    void Start()
    {
        TextMeshProUGUI tmpText = GetComponentInChildren<TextMeshProUGUI>();
        level = tmpText.text;

        buttonImage = GetComponent<Image>();

        try
        {
            completionTick = transform.Find("Tick").gameObject;
        }
        catch (NullReferenceException)
        {
            Debug.LogWarning("Check icon is missing for level " + level + "!");
        }

        alertManager = GameObject.Find("Popup").GetComponent<AlertManager>();
    }

    

    void Update() 
    {
        var tempColor = buttonImage.color;
        tempColor.a = LevelDependency.Instance.DMInstance.IsLocked(level) ? 0.7f : 1f;
        buttonImage.color = tempColor;

        if (completionTick != null)
        {
            completionTick.SetActive(false);
            if (ProgressManager.Instance.GameProgress.IsCompleted(level))
            {
                completionTick.SetActive(true);
            }
        }
    }


    public void OpenScene()
    {

        SFXManager.SFXInstance.Audio.PlayOneShot(SFXManager.SFXInstance.Click);

        if (LevelDependency.Instance.DMInstance.IsLocked(level))
        {
            

            alertManager.ShowText(String.Format(
                "Collect the gem in {0} to unlock this!",
                String.Join(", ", LevelDependency.Instance.DMInstance.GetGemDependency(level))
            ));

            


        }
        else
        {
            LevelManager.Instance.JumpToLevel(level);
            //SFXManager.SFXInstance.Audio.PlayOneShot(SFXManager.SFXInstance.Click);

        }
    }
}
