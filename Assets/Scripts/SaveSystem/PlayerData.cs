[System.Serializable]
public class PlayerData
{ 
    
    public bool loop;
    public int indexOfSong;
    public float volume;
    
    
    public PlayerData()
    {
        loop = SaveSystem.loop;
        indexOfSong = SaveSystem.indexOfSong;
        volume = SaveSystem.volume;
    }
}
