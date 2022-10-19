using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockSystem : MonoBehaviour
{
    
    public static bool lockMode = true;

    public Button[] levelButtons;

    void Start()
    {

        if(lockMode){
            foreach (Button b in levelButtons)
            b.interactable = false;

            int tmpNum = LevelEndOverlay.NumLevelsCompleted;

            for (int i = 0; i < tmpNum ;i++)
                levelButtons[i].interactable = true;

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FreeModePressed(){
        foreach (Button b in levelButtons)
        b.interactable = true;

        lockMode = false;
    }

    public void LockModePressed(){

        lockMode = true;
        
        foreach (Button b in levelButtons)
            b.interactable = false;

        int tmpNum = LevelEndOverlay.NumLevelsCompleted;

        for (int i = 0; i < tmpNum ;i++)
            levelButtons[i].interactable = true;
    }

}
