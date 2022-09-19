using System.IO;
using UnityEngine;

public static class Analytics
{
    private static string directory = "/Users/ashutoshsharma/Documents/Course_Book_PDFs/CSCI-526-Games/UNITY PROJECTS/AnalyticsData/";
    private static string fileName = "MyData.txt";

    public static void Save(SaveObject so)
    {
        Debug.Log("Inside Save Function");
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }
        
        string json = JsonUtility.ToJson(so);
        File.WriteAllText(directory+fileName, json);
    }

}
