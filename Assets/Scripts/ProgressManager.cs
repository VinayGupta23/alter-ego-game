using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameProgress
{
    // Workaround: Unity does not support serialization of hashsets :(
    // Using a synchronized storage with lists for writing/reading to file.
    [Serializable]
    private class SerializableGameProgress
    {
        public List<string> completedLevels = new List<string>();
        public List<string> gemCollectedLevels = new List<string>();
        public List<string> secretCollectedLevels = new List<string>();
    }

    private HashSet<string> completedLevels;
    private HashSet<string> gemCollectedLevels;
    private HashSet<string> secretCollectedLevels;
    private SerializableGameProgress serializable;

    public bool IsCompleted(string levelName)
    {
        return completedLevels.Contains(levelName);
    }

    public bool IsGemCollected(string levelName)
    {
        return gemCollectedLevels.Contains(levelName);
    }

    public bool IsSecretCollected(string levelName)
    {
        return secretCollectedLevels.Contains(levelName);
    }

    public int Gems()
    {
        return gemCollectedLevels.Count;
    }

    public int Secrets()
    {
        return secretCollectedLevels.Count;
    }

    public bool IsGemFound(string levelname) {
        return Constants.Gems.Contains(levelname);
    }

    public void MarkComplete(string levelName, bool gemCollected = false, bool secretCollected = false)
    {
        bool success = completedLevels.Add(levelName);
        if (success)
        {
            serializable.completedLevels.Add(levelName);
        }

        if (gemCollected)
        {
            success = gemCollectedLevels.Add(levelName);
            if (success)
            {
                serializable.gemCollectedLevels.Add(levelName);
            }
        }

        if (secretCollected)
        {
            success = secretCollectedLevels.Add(levelName);
            if (success)
            {
                serializable.secretCollectedLevels.Add(levelName);
            }
        }

        Save(this);
    }

    public void Reset()
    {
        completedLevels.Clear();
        gemCollectedLevels.Clear();
        secretCollectedLevels.Clear();

        serializable.completedLevels.Clear();
        serializable.gemCollectedLevels.Clear();
        serializable.secretCollectedLevels.Clear();
        
        Save(this);
    }

    // Static section for load/save methods

    private static readonly string VERSION_KEY = "version";
    private static readonly string PROGRESS_KEY = "progress";

    public static GameProgress Load()
    {
        GameProgress gp = new GameProgress();
        string version = PlayerPrefs.GetString(VERSION_KEY, "");
        string progressRaw = PlayerPrefs.GetString(PROGRESS_KEY, "{}");

        if (version != Application.version)
        {
            gp.serializable = new SerializableGameProgress();
            gp.completedLevels = new HashSet<string>();
            gp.gemCollectedLevels = new HashSet<string>();
            gp.secretCollectedLevels = new HashSet<string>();

            // Overwrite any obsolete data as the version changed
            Save(gp);
        }
        else
        {
            gp.serializable = JsonUtility.FromJson<SerializableGameProgress>(progressRaw);
            gp.completedLevels = new HashSet<string>(gp.serializable.completedLevels);
            gp.gemCollectedLevels = new HashSet<string>(gp.serializable.gemCollectedLevels);
            gp.secretCollectedLevels = new HashSet<string>(gp.serializable.secretCollectedLevels);
        }

        return gp;
    }
    
    // Note: This updates the PlayerPrefs object, not directly the underlying storage.
    //       Unity automatically writes to storage when application is closed.
    private static void Save(GameProgress gp)
    {
        PlayerPrefs.SetString(VERSION_KEY, Application.version);
        string progressRaw = JsonUtility.ToJson(gp.serializable);
        PlayerPrefs.SetString(PROGRESS_KEY, progressRaw);
    }
}

public class ProgressManager : MonoBehaviour
{
    private static ProgressManager _instance;
    public static ProgressManager Instance => _instance;

    private GameProgress _gameProgress;
    public GameProgress GameProgress => _gameProgress;

    // Start is called before the first frame update
    void Start()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject);

        _gameProgress = GameProgress.Load();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
