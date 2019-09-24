using System.Collections.Generic;
using System.Threading.Tasks;
using qwtfarena.Domain.Models;

namespace qwtfarena.Domain.Repositories
{
    public interface IDiscordVoiceChannelRepository
    {
         Task<IEnumerable<DiscordVoiceChannel>> ListAsync();
    }
}