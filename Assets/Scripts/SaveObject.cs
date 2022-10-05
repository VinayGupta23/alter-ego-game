using System;
using System.Diagnostics;

public class SaveObject
{
    public string playerName;
    public string level;
    public int playerDeaths;
    public int cloneDeaths;
    public int restarts;
    public Stopwatch attemptStopwatch;

    public SaveObject()
    {
        this.playerName = "";
        this.level = "";
        this.playerDeaths = 0;
        this.cloneDeaths = 0;
        this.restarts = 0;
        this.attemptStopwatch = Stopwatch.StartNew();
    }
}
