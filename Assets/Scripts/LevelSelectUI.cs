using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class LevelSelectUI : MonoBehaviour
{
    private Toggle freeModeToggle;
    private Image secretImage;
    private TextMeshProUGUI secretText;
    private AlertManager alertManager;
    private bool secretUnlocked = false;

    [SerializeField]
    private Sprite secretMissingIcon;
    [SerializeField]
    private Sprite secretTakenIcon;

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

        // Configure secret icon
        secretImage = transform.Find("SecretAbility").GetComponent<Image>();
        secretText = transform.Find("SecretAbility/SecretText").GetComponent<TextMeshProUGUI>();
        alertManager = transform.Find("Popup").GetComponent<AlertManager>();
    }

    // Update is called once per frame
    void Update()
    {
        secretUnlocked = (ProgressManager.Instance.GameProgress.Secrets() == Constants.TotalSecrets) || LevelDependency.Instance.DMInstance.FreeMode;
        if (secretUnlocked)
        {
            secretImage.sprite = secretTakenIcon;
            secretText.text = "F";
            secretText.color = new Color(45 / 255, 49 / 255, 68 / 255);
        }
        else
        {
            secretImage.sprite = secretMissingIcon;
            secretText.text = "?";
            secretText.color = Color.white;
        }
    }

    public void GoBack()
    {
        LevelManager.Instance.PreviousScene();
    }


    public void Reset() 
    {
        Debug.Log("Reset requested.");
        ProgressManager.Instance.GameProgress.Reset();
    }

    public void SetFreeMode()
    {
        LevelDependency.Instance.DMInstance.FreeMode = freeModeToggle.isOn;
    }

    public void CheckSecretStatus()
    {
        alertManager.ShowText(
            secretUnlocked ? "Press 'F' to use your special ability!" : "Need more parts...");
    }
}
