using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using UnityEditor;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;

public class Analytics : MonoBehaviour
{
    private static Analytics _instance;
    public static Analytics Instance => _instance;

    // Ashutosh's form
    //private static string URL = "https://docs.google.com/forms/u/1/d/e/1FAIpQLSfTGamJ38JWu5cGsslKp83ijYCk5o4awjrRxqp8Q14h_PO-LQ/formResponse";

    //Smaran's google form
    private static string URL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSeQOE5oQ8iT3QJ9JvJJsY8H2eTPVAzFICRnWNUCJggAUg-qHA/formResponse";
    private SaveObject saveObject;
    private long sessionID;
    private string applicationVersion;
    
    void Start()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject);

        saveObject = new SaveObject();
        sessionID = DateTime.Now.Ticks;
        applicationVersion = Application.version;

        SetGuidIfNotSet();
    }

    private void SetGuidIfNotSet()
    {
        if (!PlayerPrefs.HasKey("GUID"))
        {
            PlayerPrefs.SetString("GUID", System.Guid.NewGuid().ToString());
        }
    }

    public void SetCameraDimension(float height, float width)
    {
        saveObject.cameraHeight = height;
        saveObject.cameraWidth = width;
    }

    public void SetAttemptStopwatch(Stopwatch sw)
    {
        saveObject.attemptStopwatch = sw;
    }

    public void SetPlayerName(string playerName)
    {
        saveObject.playerName = playerName;
    }

    public void SetLevelName(string level)
    {
        saveObject.level = level;
    }

    public void RecordPlayerDeath(string causeOfDeath, Vector3 position)
    {
        saveObject.postionOfDeathPlayer = position.ToString();
        saveObject.causeOfDeathPlayer = causeOfDeath.Split(".")[0];
        saveObject.playerDeaths++;
    }

    public void RecordCloneDeath(string causeOfDeath, Vector3 position)
    {
        saveObject.causeAndPositionOfDeathClone.Add(Tuple.Create(causeOfDeath.Split(".")[0], position.ToString()));
        saveObject.cloneDeaths++;
    }

    public void RecordLevelRestart()
    {
        saveObject.restarts++;
    }

    public void RecordPillCollection()
    {
        saveObject.collectedPill = true;
    }
    
    public void RecordGemCollection()
    {
        saveObject.collectedGem = true;
    }

    public int GetPlayerDeaths()
    {
        return saveObject.playerDeaths;
    }
    
    public int GetCloneDeaths()
    {
        return saveObject.cloneDeaths;
    }
    public int GetRestarts()
    {
        return saveObject.restarts;
    }
    public String GetPlayerName() {

        return saveObject.playerName;
    }
    public String GetLevel()
    {

        return saveObject.level;
    }

    public String GetCauseOfPlayerDeath()
    {
        return saveObject.causeOfDeathPlayer;
    }

    public String GetPositionOfPlayerDeath()
    {
        return saveObject.postionOfDeathPlayer;
    }
    
    public String GetCollectedPill()
    {
        return saveObject.collectedPill.ToString();
    }
    
    public String GetCollectedGem()
    {
        return saveObject.collectedGem.ToString();
    }

    public String GetCommaSeparatedStringForClone(List<Tuple<string,string>> cloneStats)
    {
        StringBuilder sb = new StringBuilder();
        foreach (var tuple in saveObject.causeAndPositionOfDeathClone)
        {
            sb.Append(tuple.Item1 + ":" + tuple.Item2+",");
        }

        return sb.ToString().TrimEnd(',');
    }

    public void Save()
    {
        saveObject.attemptStopwatch.Stop();
        string totalTime = saveObject.attemptStopwatch.Elapsed.TotalSeconds.ToString("F");
        SetPlayerName("TestUser");
        SetLevelName(SceneManager.GetActiveScene().name);
        Camera cam = FindObjectOfType<Camera>();
        float height = cam.orthographicSize;
        float width = height * cam.aspect;
        SetCameraDimension(height, width);

        // Debug.Log("App Version :"+applicationVersion);
        // Debug.Log("Cam H : "+saveObject.cameraHeight+" Cam W : "+saveObject.cameraWidth);
        // Debug.Log("Inside Save Function");
        // Debug.Log(totalTime);
        //
        // Debug.Log("Player Death Reason : "+GetCauseOfPlayerDeath());
        // Debug.Log("Player Death Position : "+GetPositionOfPlayerDeath());
        // Debug.Log("Clone Death Stats : ");
        // foreach (var tuple in saveObject.causeAndPositionOfDeathClone)
        // {
        //     Debug.Log(tuple.Item1 + " : " + tuple.Item2);
        // }
        //
        // Debug.Log("Collected Pill : "+saveObject.collectedPill);
        
        StartCoroutine(Post(sessionID, totalTime));
        ResetSaveObject();
    }

    public void ResetSaveObject()
    {
        saveObject.playerDeaths = 0;
        saveObject.cloneDeaths = 0;
        saveObject.restarts = 0;
        saveObject.attemptStopwatch.Restart();
        saveObject.causeOfDeathPlayer = "";
        saveObject.postionOfDeathPlayer = "";
        saveObject.causeAndPositionOfDeathClone = new System.Collections.Generic.List<System.Tuple<string, string>>();
        saveObject.collectedPill = false;
        saveObject.collectedGem = false;
        saveObject.cameraHeight = 0;
        saveObject.cameraWidth = 0;
    }

    private IEnumerator Post(long sessionID, string totalTime)
    {
        WWWForm form = new WWWForm();
        //smaran form fields
        form.AddField("entry.1744685662", sessionID.ToString());
        form.AddField("entry.1338829509", saveObject.playerName);
        form.AddField("entry.446291850", saveObject.level);
        form.AddField("entry.1394998312", saveObject.playerDeaths);
        form.AddField("entry.1382578195", saveObject.cloneDeaths);
        form.AddField("entry.1974086555", totalTime);
        form.AddField("entry.1179426767", saveObject.restarts);
        form.AddField("entry.869016631", saveObject.causeOfDeathPlayer);
        form.AddField("entry.294773931", saveObject.postionOfDeathPlayer);
        form.AddField("entry.104374970", GetCommaSeparatedStringForClone(saveObject.causeAndPositionOfDeathClone));
        form.AddField("entry.2075508212", saveObject.collectedPill.ToString());
        form.AddField("entry.1887514904", saveObject.collectedGem.ToString());
        form.AddField("entry.1351303107", applicationVersion);
        form.AddField("entry.313515096", saveObject.cameraHeight.ToString());
        form.AddField("entry.2117992083", saveObject.cameraWidth.ToString());
        form.AddField("entry.652434414", PlayerPrefs.GetString("GUID"));

        //Ashutosh form fields
        // form.AddField("entry.1881344749", sessionID.ToString());
        // form.AddField("entry.1270308506", saveObject.playerName);
        // form.AddField("entry.846070688", saveObject.level);
        // form.AddField("entry.258147173", saveObject.playerDeaths);
        // form.AddField("entry.969688975", saveObject.cloneDeaths);
        // form.AddField("entry.1115030971", totalTime);
        // form.AddField("entry.1709230882", saveObject.restarts);
        // form.AddField("entry.1351667745", saveObject.causeOfDeathPlayer);
        // form.AddField("entry.1666558369", saveObject.postionOfDeathPlayer);
        // form.AddField("entry.746886556", GetCommaSeparatedStringForClone(saveObject.causeAndPositionOfDeathClone));
        // form.AddField("entry.104393791", saveObject.collectedPill.ToString());

        using (UnityWebRequest www = UnityWebRequest.Post(URL, form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Form upload completed");
                Debug.Log("__________________________________________");
            }
        }
    }
}
