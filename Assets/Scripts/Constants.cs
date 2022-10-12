using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Constants
{
    public static readonly int TotalGems = 3;
    public static readonly List<string> LevelNames = new List<string>
    {
        "0-1",
        "0-2",
        "0-3",
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
