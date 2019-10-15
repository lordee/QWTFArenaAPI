using System.Collections.Generic;

namespace qwtfarena.Domain.Models
{
    public class SSQCPlayer
    {
        public int GameID { get; set; }
        public SSQCGameInfo SSQCGameInfo { get; set; }
        
        public int PlayerStateID { get; set; }
        public string Name { get; set; }
        public int Team { get; set; }
        public int Class { get; set; }
        public int TF_ID { get; set; }
        public bool Player { get; set; }
    }
}