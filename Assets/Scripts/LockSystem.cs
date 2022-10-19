using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LockSystem : MonoBehaviour
{
    // Start is called before the first frame update
    public Button[] levelButtons;


    void Start()
    {
        foreach (Button b in levelButtons)
            b.interactable = false;

        int reachedLevel = PlayerPrefs.GetInt("ReaachedLevel",1);

        for (int i = 0; i<reachedLevel;i++)
            levelButtons[i].interactable = true;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
