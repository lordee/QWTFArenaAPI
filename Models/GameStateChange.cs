using System.Collections.Generic;

public class GameStateChange
{
    public int GameID;
    public string ServerName;
    public float GameTime;
    public string EventType;
    public string Map;
    public string Initiator;
    public List<GamePlayer> Players = new List<GamePlayer>();
    public List<GamePlayer> Spectators = new List<GamePlayer>();
    

}