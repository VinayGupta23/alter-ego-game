using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    public string level;
    // public string test;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OpenScene(){
        LevelManager.Instance.JumpToLevel(level);
    }

}

