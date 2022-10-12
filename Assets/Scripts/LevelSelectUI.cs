using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelSelectUI : MonoBehaviour
{
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
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GoBack()
    {
        LevelManager.Instance.PreviousScene();
    }
}
