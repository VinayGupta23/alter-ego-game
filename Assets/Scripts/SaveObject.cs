[System.Serializable]

public class SaveObject
{
    public string playerName;
    public string level;
    public int playerDeaths;
    public int cloneDeaths;

    
    public SaveObject(){}
    public SaveObject(string playerName, int playerDeaths, int cloneDeaths)
    {
        this.playerName = playerName;
        this.playerDeaths = playerDeaths;
        this.cloneDeaths = cloneDeaths;
    }
}
