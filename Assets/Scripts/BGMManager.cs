using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMManager : MonoBehaviour
{
    private static BGMManager instance;
    public static BGMManager Instance => instance;

    public AudioSource Audio;
    public AudioClip MenuMusic;
    public AudioClip LevelMusic;

    private string lastScene = "";

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        SceneManager.activeSceneChanged += activeSceneChanged;
    }

    private void activeSceneChanged(Scene _current, Scene next)
    {
        string nextScene = next.name;
        Debug.Log(string.Format("'{0}' --> '{1}'", lastScene, nextScene));

        if (lastScene == "")
        {
            Audio.clip = isMenuType(nextScene) ? MenuMusic : LevelMusic;
            Audio.Play();
        }
        else if (isMenuType(lastScene) && !isMenuType(nextScene))
        {
            // Moved from menu to level
            Audio.clip = LevelMusic;
            Audio.Play();
        }
        else if (!isMenuType(lastScene) && isMenuType(nextScene))
        {
            // Moved from level to menu
            Audio.clip = MenuMusic;
            Audio.Play();
        }

        lastScene = nextScene;
    }

    private bool isMenuType(string sceneName)
    {
        return (sceneName == "MainMenu" || sceneName == "LevelSelect" || sceneName == "Credits");
    }
}
