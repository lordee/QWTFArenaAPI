using System.Collections.Generic;

namespace qwtfarena.Domain.Models
{
    public class DiscordVoiceUser
    {
        public string DiscordVoiceUserID { get; set; }
        public string Name { get; set; }

        public string DiscordVoiceChannelID { get; set; }
        public DiscordVoiceChannel DiscordVoiceChannel { get; set; }
    }
}