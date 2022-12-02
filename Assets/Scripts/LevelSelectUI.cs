using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class LevelSelectUI : MonoBehaviour
{
    private Toggle freeModeToggle;
    private Button secretButton;
    private Image secretImage;
    private TextMeshProUGUI secretText;
    private TextMeshProUGUI secretDetails;
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

        GameObject gemStats = transform.Find("GemIcon/GemStats").gameObject;
        TextMeshProUGUI levelNameText = gemStats.GetComponent<TextMeshProUGUI>();
        levelNameText.text = string.Format(
            "{0} / {1}",
            ProgressManager.Instance.GameProgress.Gems(),
            Constants.TotalGems
        );

        freeModeToggle = GameObject.Find("FreeMode").GetComponent<Toggle>();
        freeModeToggle.isOn = LevelDependency.Instance.DMInstance.FreeMode;

        // Configure secret icon
        secretButton = transform.Find("SecretAbility").GetComponent<Button>();
        secretImage = transform.Find("SecretAbility").GetComponent<Image>();
        secretText = transform.Find("SecretAbility/SecretText").GetComponent<TextMeshProUGUI>();
        secretDetails = transform.Find("SecretDetails").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        secretUnlocked = (ProgressManager.Instance.GameProgress.Secrets() == Constants.TotalSecrets) || LevelDependency.Instance.DMInstance.FreeMode;
        if (secretUnlocked)
        {
            secretButton.interactable = true;
            secretImage.sprite = secretTakenIcon;
            secretText.text = "F";
            secretText.color = Color.black;
            secretDetails.text = "Secret unlocked! Click the diamond to learn more!";
        }
        else
        {
            secretButton.interactable = false;
            secretImage.sprite = secretMissingIcon;
            secretText.text = "?";
            secretText.color = Color.white;
            secretDetails.text = "Secret: Find all hidden pieces and come back here!";
        }
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
        EventSystem.current.SetSelectedGameObject(this.gameObject.transform.Find("BackButton").gameObject, null);

    }

    public void SetFreeMode()
    {
        LevelDependency.Instance.DMInstance.FreeMode = freeModeToggle.isOn;
        SFXManager.SFXInstance.Audio.PlayOneShot(SFXManager.SFXInstance.Click);
        EventSystem.current.SetSelectedGameObject(this.gameObject.transform.Find("BackButton").gameObject, null);
    }

    public void CheckSecretStatus()
    {
        if (secretUnlocked)
        {
            LevelManager.Instance.JumpToLevel("SECRET");
        }
    }
}
