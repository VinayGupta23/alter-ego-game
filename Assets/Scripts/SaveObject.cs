using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class SaveObject
{
    public string playerName;
    public string level;
    public int playerDeaths;
    public int cloneDeaths;
    public int restarts;
    public Stopwatch attemptStopwatch;
    public string causeOfDeathPlayer;
    public string postionOfDeathPlayer;
    public List<Tuple<string,string>> causeAndPositionOfDeathClone;
    public Boolean collectedPill;
    public Boolean collectedGem;
    public float cameraHeight;
    public float cameraWidth;

    public SaveObject()
    {
        this.playerName = "";
        this.level = "";
        this.playerDeaths = 0;
        this.cloneDeaths = 0;
        this.restarts = 0;
        this.attemptStopwatch = Stopwatch.StartNew();
        this.causeOfDeathPlayer = "";
        this.postionOfDeathPlayer = "";
        this.causeAndPositionOfDeathClone = new System.Collections.Generic.List<System.Tuple<string, string>>();
        this.collectedPill = false;
        this.collectedGem = false;
        this.cameraHeight = 0;
        this.cameraWidth = 0;
    }
}
