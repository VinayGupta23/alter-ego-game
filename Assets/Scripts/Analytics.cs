using UnityEngine;
using System;
using System.Collections;
using UnityEngine.Networking;

public class Analytics : MonoBehaviour
{
    private static Analytics _instance;
    public static Analytics Instance => _instance;
    
    //Smaran's google form
    private static string URL = "https://docs.google.com/forms/u/1/d/e/1FAIpQLSfTGamJ38JWu5cGsslKp83ijYCk5o4awjrRxqp8Q14h_PO-LQ/formResponse";
    private SaveObject saveObject;
    
    void Start()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }

        _instance = this;
        DontDestroyOnLoad(gameObject);

        saveObject = new SaveObject();
    }

    public void SetPlayerName(string playerName)
    {
        saveObject.playerName = playerName;
    }

    public void SetLevelName(string level)
    {
        saveObject.level = level;
    }

    public void RecordPlayerDeath()
    {
        saveObject.playerDeaths++;
    }

    public void RecordCloneDeath()
    {
        saveObject.cloneDeaths++;
    }

    public int GetPlayerDeaths()
    {
        return saveObject.playerDeaths;
    }
    
    public int GetCloneDeaths()
    {
        return saveObject.cloneDeaths;
    }
    public String GetPlayerName() {

        return saveObject.playerName;
    }
    public String GetLevel()
    {

        return saveObject.level;
    }

    public void Save()
    {
        // This does not work, currently we are using low-level APIs from GoalTrigger.cs
        Debug.Log("Inside Save Function");
        StartCoroutine(Post(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
        ResetSaveObject();
    }

    public void ResetSaveObject()
    {
        saveObject.playerDeaths = 0;
        saveObject.cloneDeaths = 0;
    }

    private IEnumerator Post(string sessionID)
    {
        WWWForm form = new WWWForm();
        form.AddField("entry.1881344749", sessionID);
        form.AddField("entry.1270308506", saveObject.playerName);
        form.AddField("entry.846070688", saveObject.level);
        form.AddField("entry.258147173", saveObject.playerDeaths);
        form.AddField("entry.969688975", saveObject.cloneDeaths);

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
            }
        }
    }
}
