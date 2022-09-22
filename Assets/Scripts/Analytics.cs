using System.IO;
using UnityEngine;


public static class Analytics
{
    private static string directory = "/Users/ashutoshsharma/Documents/Course_Book_PDFs/CSCI-526-Games/UNITY PROJECTS/AnalyticsData/";
    private static string fileName = "MyData.txt";
    private static SaveObject saveObject = new SaveObject("Ashutosh", 0, 0);

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

    public static void Save()
    {
        Debug.Log("Inside Save Function");
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }
        
        string json = JsonUtility.ToJson(saveObject);
        File.WriteAllText(directory+fileName, json);
    }

}
