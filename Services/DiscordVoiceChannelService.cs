using System.Collections.Generic;
using System.Threading.Tasks;
using qwtfarena.Domain.Models;
using qwtfarena.Domain.Services;
using qwtfarena.Domain.Repositories;

namespace qwtfarena.Services
{
    public class DiscordVoiceChannelService : IDiscordVoiceChannelService
    {
        private readonly IDiscordVoiceChannelRepository _discordVoiceChannelRepository;

        public DiscordVoiceChannelService(IDiscordVoiceChannelRepository discordVoiceChannelRepository)
        {
            this._discordVoiceChannelRepository = discordVoiceChannelRepository;
        }

        public async Task<IEnumerable<DiscordVoiceChannel>> ListAsync()
        { 
            return await _discordVoiceChannelRepository.ListAsync();
        }
    }
}