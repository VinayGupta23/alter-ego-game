using Firebase.Firestore;

[FirestoreData]
[System.Serializable]

public struct SaveObjectfb
{
    [FirestoreProperty]
    public string playerName { get; set; }

    [FirestoreProperty]
    public string level { get; set; }

    [FirestoreProperty]
    public int playerDeaths { get; set; }

    [FirestoreProperty]
    public int cloneDeaths { get; set; }
}

public class SaveObject
{
    public string playerName;
    public string level;
    public int playerDeaths;
    public int cloneDeaths;

    public SaveObject()
    {
        this.playerName = "";
        this.level = "";
        this.playerDeaths = 0;
        this.cloneDeaths = 0;
    }
}
