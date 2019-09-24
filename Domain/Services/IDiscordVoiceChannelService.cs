using System.Collections.Generic;
using System.Threading.Tasks;
using qwtfarena.Domain.Models;

namespace qwtfarena.Domain.Services
{
    public interface IDiscordVoiceChannelService
    {
         Task<IEnumerable<DiscordVoiceChannel>> ListAsync();
    }
}