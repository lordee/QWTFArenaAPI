using System.Collections.Generic;

namespace qwtfarena.Domain.Models
{
    public class SSQCPlayerState
    {
        public int GameID { get; set; }
        public float GameTime { get; set; }
        public string EventType { get; set; }
        public string EventChange { get; set; }
        public int TF_ID { get; set; }
    }
}