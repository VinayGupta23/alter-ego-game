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
        "7-3",
        "B-1",
        "B-2",
        "B-3"
    };

    //Need to update the existance of gem here after adding gem to any level.
    public static readonly HashSet<string> Gems = new HashSet<string> {
        "4-2",
        "6-2",
        "7-2"
    };
    public static readonly int TotalGems = Gems.Count;

    public static Dictionary<string, List<string>> LevelDependency = new Dictionary<string, List<string>> {
        // No locking of levels as of now
    };
    public static Dictionary<string, List<string>> GemDependency = new Dictionary<string, List<string>> {
        { "B-1", new List<string> { "4-2" } },
        { "B-2", new List<string> { "6-2" } },
        { "B-3", new List<string> { "7-2" } }
    };

    public enum GameColors
    {
        Neutral = 0,
        Accent1 = 1,
        Accent2 = 2,
        Accent3 = 3
    }

    public static readonly Color[] COLOR_OPTIONS = {
        new Color(1, 1, 1),            // No change
        new Color(1, 0.8516f, 0.6f),   // Tint lime
        new Color(1, 0.7f, 0.8955f),   // Tint pink
        new Color(0.65f, 0.8998f, 1)   // Tint blue
    };
}
