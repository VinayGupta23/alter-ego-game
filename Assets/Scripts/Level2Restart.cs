using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2Restart : MonoBehaviour
{
    // Start is called before the first frame update
    public void level2restart()
    {
        SceneManager.LoadScene("Level2");
    }

}
