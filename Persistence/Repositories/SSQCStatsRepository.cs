using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using qwtfarena.Domain.Models;
using qwtfarena.Domain.Repositories;
using qwtfarena.Persistence.Contexts;

namespace qwtfarena.Persistence.Repositories
{
    public class SSQCStatsRepository : BaseRepository, ISSQCStatsRepository
    {
        public SSQCStatsRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<int> GameStatusChange(int gameid, float gametime, string eventtype, string initiator)
        {
            // insert entry, return data

            SSQCGameState gs = new SSQCGameState
            {
                GameTime = gametime,
                EventType = eventtype,
                Initiator = initiator,
                GameID = gameid
            };
            
            await _context.AddAsync(gs);

            return await _context.SaveChangesAsync();
        }

        public async Task<int> GameStart(string servername, float gametime, string eventtype, string map, string initiator)
        {
            SSQCGameInfo gi = new SSQCGameInfo
            {
                ServerName = servername
                , Map = map
            };

            // insert entry, return gameid
            SSQCGameState gs = new SSQCGameState
            {
                GameTime = gametime,
                EventType = eventtype,
                Initiator = initiator
            };

            gi.GameStates.Add(gs);

            await _context.AddAsync(gi);
            _context.SaveChanges();

            return gi.GameID;
        }
    }
}