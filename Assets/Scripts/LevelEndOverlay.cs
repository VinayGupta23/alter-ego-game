using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.EventSystems;

public class LevelEndOverlay : MonoBehaviour
{
    public bool isOrphanLevel = false;
    [SerializeField]
    GameObject secretGameObject;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Return) | Input.GetKey(KeyCode.Space))
        {
            LoadNext();
            ResetFirstSelected();
        }
    }

    public void SetReminder(string reminder)
    {
        TextMeshProUGUI textComponent = secretGameObject.GetComponent<TextMeshProUGUI>();
        textComponent.text = reminder;
    }

    public void Display()
    {
        Time.timeScale = 0f;
        this.gameObject.SetActive(true);
        SetFirstSelected();
    }

    public void LoadNext()
    {
        Time.timeScale = 1f;
        if (isOrphanLevel)
        {
            SFXManager.SFXInstance.Audio.PlayOneShot(SFXManager.SFXInstance.Click);
            LevelManager.Instance.LevelSelect();
        }
        else
        {
            SFXManager.SFXInstance.Audio.PlayOneShot(SFXManager.SFXInstance.Click);
            LevelManager.Instance.NextLevel();
        }
        ResetFirstSelected();
    }
    
    public void LoadLevelSelect()
    {
        Time.timeScale = 1f;
        LevelManager.Instance.LevelSelect();
        ResetFirstSelected();
    }
    
    private void SetFirstSelected()
    {
        EventSystem.current.SetSelectedGameObject(this.gameObject.transform.Find("Menu").gameObject, null);
    }

    private void ResetFirstSelected()
    {
        EventSystem.current.SetSelectedGameObject(null, null);
    }
}
