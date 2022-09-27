using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelRestart : MonoBehaviour
{
    // Start is called before the first frame update
    public void Restart()
    {
        LevelManager.Instance.RestartLevel();
    }

}