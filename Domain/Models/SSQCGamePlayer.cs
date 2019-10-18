namespace qwtfarena.Domain.Models
{
    public class SSQCGamePlayer
    {
        public int GameID { get; set; }
        public SSQCGameInfo SSQCGameInfo { get; set; }
        
        public int PlayerID { get; set; }
        public string Name { get; set; }
        public int Team { get; set; }
        public int Class { get; set; }
        public int TF_ID { get; set; }
        public bool Player { get; set; }
    }
}