using System.Collections.Generic;

namespace qwtfarena.Domain.Models
{
    public class SSQCGameState
    {
        public int GameID { get; set; }
        public SSQCGameInfo SSQCGameInfo { get; set; }
        
        public int GameStateID { get; set; }
        public float GameTime { get; set; }
        public string EventType { get; set; }
        public string Initiator { get; set; }
    }
}