using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DependecyManager
{
    public bool FreeMode = false;

    private Dictionary<string, List<string>> Dependency = new Dictionary<string, List<string>>();

    // Ideally this should be set from UI. 
    public void SetDependency()
    {
        Dependency.Add("7-1", new List<string> { "6-3" });
        Dependency.Add("7-2", new List<string> { "6-3" });
    }

    public static DependecyManager Load() {
        DependecyManager dm = new DependecyManager();
        dm.SetDependency();
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
    [SerializeField]
    private bool FreeMode = false;

    private static LevelDependency _instance;
    public static LevelDependency Instance => _instance;

    private DependecyManager _DM_instance;
    public DependecyManager DMInstance => _DM_instance;

    public void Start()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject);

        _DM_instance = DependecyManager.Load();
        _DM_instance.SetFreeMode(FreeMode);

    }



}

