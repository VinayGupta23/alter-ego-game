using System;
using System.Diagnostics;

public class SaveObject
{
    public string playerName;
    public string level;
    public int playerDeaths;
    public int cloneDeaths;
    public Stopwatch levelStopwatch;

    public SaveObject()
    {
        this.playerName = "";
        this.level = "";
        this.playerDeaths = 0;
        this.cloneDeaths = 0;
        this.levelStopwatch = Stopwatch.StartNew();
    }
}
