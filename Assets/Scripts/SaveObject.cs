[System.Serializable]

public class SaveObject
{
    public string playerName;
    public string level;
    public int playerDeaths;
    public int cloneDeaths;

    public SaveObject(string playerName, string level, int playerDeaths, int cloneDeaths)
    {
        this.playerName = playerName;
        this.level = level;
        this.playerDeaths = playerDeaths;
        this.cloneDeaths = cloneDeaths;
    }
}
