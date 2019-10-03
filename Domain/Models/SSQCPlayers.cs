using System.Collections.Generic;

namespace qwtfarena.Domain.Models
{
    public class SSQCPlayers
    {
        public int GameID { get; set; }
        public SSQCGameInfo SSQCGameInfo { get; set; }
        
        public int PlayerStateID { get; set; }
        public string Name { get; set; }
        public string Team { get; set; }
        public string Class { get; set; }
        public string EventType { get; set; }
    }
}