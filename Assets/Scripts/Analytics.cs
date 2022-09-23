using System.IO;
using UnityEngine;
using System;
using System.Globalization;
using System.Collections;
using UnityEngine.Networking;

public static class Analytics
{
    private static string URL = "https://docs.google.com/forms/u/1/d/e/1FAIpQLSfTGamJ38JWu5cGsslKp83ijYCk5o4awjrRxqp8Q14h_PO-LQ/formResponse";

    private static SaveObject saveObject = new SaveObject();

    public static void SetPlayerName(string playerName)
    {
        saveObject.playerName = playerName;
    }

    public static void SetLevelName(string level)
    {
        saveObject.level = level;
    }

    public static void RecordPlayerDeath()
    {
        saveObject.playerDeaths++;
    }

    public static void RecordCloneDeath()
    {
        saveObject.cloneDeaths++;
    }

    public static int GetPlayerDeaths()
    {
        return saveObject.playerDeaths;
    }
    
    public static int GetCloneDeaths()
    {
        return saveObject.cloneDeaths;
    }
    public static String GetPlayerName() {

        return saveObject.playerName;
    }
    public static String GetLevel()
    {

        return saveObject.level;
    }

    public static void Save()
    {
        // This does not work, currently we are using low-level APIs from GoalTrigger.cs
        Debug.Log("Inside Save Function");
        Post(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        ResetSaveObject();
    }

    public static void ResetSaveObject()
    {
        saveObject.playerDeaths = 0;
        saveObject.cloneDeaths = 0;
    }

    public static IEnumerator Post(string sessionID)
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
