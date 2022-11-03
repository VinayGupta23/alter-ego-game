using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class LevelSelectUI : MonoBehaviour
{
    private Toggle freeModeToggle;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        GameObject gemStats = transform.Find("GemStats").gameObject;
        TextMeshProUGUI levelNameText = gemStats.GetComponent<TextMeshProUGUI>();
        levelNameText.text = string.Format(
            "{0} / {1}",
            ProgressManager.Instance.GameProgress.Gems(),
            Constants.TotalGems
        );

        freeModeToggle = GameObject.Find("FreeMode").GetComponent<Toggle>();
        freeModeToggle.isOn = LevelDependency.Instance.DMInstance.FreeMode;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GoBack()
    {
        LevelManager.Instance.PreviousScene();
        SFXManager.SFXInstance.Audio.PlayOneShot(SFXManager.SFXInstance.Click);

    }


    public void Reset() 
    {
        Debug.Log("Reset requested.");
        ProgressManager.Instance.GameProgress.Reset();
        SFXManager.SFXInstance.Audio.PlayOneShot(SFXManager.SFXInstance.Click);


    }

    public void SetFreeMode()
    {
        LevelDependency.Instance.DMInstance.FreeMode = freeModeToggle.isOn;
        SFXManager.SFXInstance.Audio.PlayOneShot(SFXManager.SFXInstance.Click);

    }
}
