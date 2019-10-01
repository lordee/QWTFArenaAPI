using System.Collections.Generic;

namespace qwtfarena.Domain.Models
{
    public class SSQCGameInfo
    {
        public int GameID { get; set; }
        public string ServerName { get; set; }
        public string Map { get; set; }
        
        public IList<SSQCGameState> GameStates {get; set; } = new List<SSQCGameState>();
    }
}