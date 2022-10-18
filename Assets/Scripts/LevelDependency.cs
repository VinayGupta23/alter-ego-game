using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DependencyManager
{
    public bool FreeMode = false;

    private Dictionary<string, List<string>> Dependency = Constants.Dependency;

    // Ideally this should be set from UI. 

    public static DependencyManager Load() {
        DependencyManager dm = new DependencyManager();
        return dm;
    }

    public void SetFreeMode(bool mode) {
        FreeMode = mode;
    }

    public List<string> GetDependency(string levelname)
    {
        Dependency.TryGetValue(levelname, out List<string> x);
        return x;
    }

    public bool IsLocked(string levelname)
    {
        if (FreeMode == true) { 
            return false;
        }
        List<string> levels = GetDependency(levelname);
        if (levels != null) {
            foreach (string level in levels)
            {
                if (ProgressManager.Instance.GameProgress.IsGemCollected(level) == false)
                {
                    return true;
                }
            }

        }
       
        return false;
    }
}

public class LevelDependency : MonoBehaviour {

    // we should get this input from game ui

    private static LevelDependency _instance;
    public static LevelDependency Instance => _instance;

    private DependencyManager _DM_instance;
    public DependencyManager DMInstance => _DM_instance;

    public void Start()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject);

        _DM_instance = DependencyManager.Load();

    }



}

