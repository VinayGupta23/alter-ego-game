using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    private string level;
    // Start is called before the first frame update
    void Start()
    {
        TextMeshProUGUI tmpText = GetComponentInChildren<TextMeshProUGUI>();
        level = tmpText.text;
    }

    public void OpenScene(){
        LevelManager.Instance.JumpToLevel(level);

       
    }



}

