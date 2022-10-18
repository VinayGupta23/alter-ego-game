using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelSelection : MonoBehaviour
{
    private string level;
    Toggle m_Toggle;

    // Start is called before the first frame update
    void Start()
    {
        TextMeshProUGUI tmpText = GetComponentInChildren<TextMeshProUGUI>();
        level = tmpText.text;
    }

    public void OpenScene(){
        LevelManager.Instance.JumpToLevel(level);

        m_Toggle = GetComponent<Toggle>();

        if (ProgressManager.Instance.GameProgress.IsCompleted(level)){
            m_Toggle.isOn = true;
        }
        
    }

}

