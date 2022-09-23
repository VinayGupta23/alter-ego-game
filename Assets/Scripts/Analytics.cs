using System.IO;
using UnityEngine;
using Firebase.Firestore;
using System;
using System.Globalization;


public static class Analytics
{
    
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
        Debug.Log("Inside Save Function");
        var saveObjectfb = new SaveObjectfb
        {
            playerName = saveObject.playerName,
            level = saveObject.level,
            playerDeaths = GetPlayerDeaths(),
            cloneDeaths = GetCloneDeaths()
        };
        Debug.Log("After fb object creation");
        DateTime now = DateTime.Now;
        CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;


        Debug.Log(now.ToString("MM-dd-yyyy-HH:mm:ss"));
        var firestore = FirebaseFirestore.DefaultInstance;
        firestore.Document("alterego/" + now.ToString("MM-dd-yyyy-HH:mm:ss")).SetAsync(saveObjectfb);
    }

}
