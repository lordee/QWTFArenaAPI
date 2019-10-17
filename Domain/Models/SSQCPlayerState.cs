namespace qwtfarena.Domain.Models
{
    public class SSQCPlayerState
    {
        public int PlayerStateID { get; set; }
        public int GameID { get; set; }
        public float GameTime { get; set; }
        public string EventType { get; set; }
        public string EventChange { get; set; }
        public int TF_ID { get; set; }
    }
}