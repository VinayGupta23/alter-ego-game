using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Constants
{
    
    public static readonly List<string> LevelNames = new List<string>
    {
        "0-1",
        "0-2",
        "1-1",
        "1-2",
        "1-3",
        "2-1",
        "2-2",
        "2-3",
        "2-4",
        "2-5",
        "3-1",
        "3-2",
        "3-3",
        "4-1",
        "4-2",
        "4-3",
        "5-1",
        "5-2",
        "5-3",
        "6-1",
        "6-2",
        "6-3",
        "7-1",
        "7-2",
        "7-3"
    };

    //Need to update the existance of gem here after adding gem to any level.
    public static readonly HashSet<string> Gems = new HashSet<string> {
        "4-1",
        "5-3",
        "6-3"
    };
    public static readonly int TotalGems = Gems.Count;

    public static Dictionary<string, List<string>> LevelDependency = new Dictionary<string, List<string>> {
        { "7-2", new List<string> { "7-1" } },
         { "7-3", new List<string> { "7-1" } }
    };
    public static Dictionary<string, List<string>> GemDependency = new Dictionary<string, List<string>> {
        { "4-2", new List<string> { "4-1" } },
         { "4-3", new List<string> { "4-1" } },
         { "7-1", new List<string> { "6-3" } }
    };
    public  enum GameColors {
        Neutral = 0,
        Accent1 = 1,
        Accent2 = 2
    }

    public static readonly Color[] COLOR_OPTIONS = {
        new Color(1, 1, 1), // No change
        new Color(1, 0.9231956f, 0.7882353f), // Tint yellow
        new Color(1, 0.7882353f, 0.9254902f), // Tint pink
    };
}
