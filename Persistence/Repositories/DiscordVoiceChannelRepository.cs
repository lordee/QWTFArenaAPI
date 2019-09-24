using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using qwtfarena.Domain.Models;
using qwtfarena.Domain.Repositories;
using qwtfarena.Persistence.Contexts;

namespace qwtfarena.Persistence.Repositories
{
    public class DiscordVoiceChannelRepository : BaseRepository, IDiscordVoiceChannelRepository
    {
        public DiscordVoiceChannelRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<DiscordVoiceChannel>> ListAsync()
        {
            return await _context.DiscordVoiceChannels.ToListAsync();
        }
    }
}