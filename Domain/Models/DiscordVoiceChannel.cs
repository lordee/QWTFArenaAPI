using System.Collections.Generic;

namespace qwtfarena.Domain.Models
{
    public class DiscordVoiceChannel
    {
        public string DiscordVoiceChannelID { get; set; }
        public string Name { get; set; }
        public IList<DiscordVoiceUser> Users { get; set; } = new List<DiscordVoiceUser>();
    }
}