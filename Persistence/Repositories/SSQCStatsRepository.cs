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

        public async Task<int> GameStateChange(int gameid, float gametime, string eventtype, string initiator)
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

        public async Task<int> GameStart(GameStateChange gsc)
        {
            SSQCGameInfo gi = new SSQCGameInfo
            {
                ServerName = gsc.ServerName
                , Map = gsc.Map
            };

            // insert entry, return gameid
            SSQCGameState gs = new SSQCGameState
            {
                GameTime = gsc.GameTime,
                EventType = gsc.EventType,
                Initiator = gsc.Initiator
            };

            List<SSQCPlayer> lp = new List<SSQCPlayer>();
            foreach (GamePlayer gp in gsc.Players)
            {
                lp.Add(new SSQCPlayer
                {
                    Name = gp.Name,
                    Team = gp.Team,
                    Class = gp.Class,
                    TF_ID = gp.TF_ID,
                    Player = true
                });
            }

            foreach (GamePlayer gp in gsc.Spectators)
            {
                lp.Add(new SSQCPlayer
                {
                    Name = gp.Name,
                    Team = gp.Team,
                    Class = gp.Class,
                    TF_ID = gp.TF_ID,
                    Player = false
                });
            }
            
            gi.Players.Add(lp);
            gi.GameStates.Add(gs);

            await _context.AddAsync(gi);
            _context.SaveChanges();

            return gi.GameID;
        }

        public async Task<int> PlayerStateChange(PlayerStateChange psc, string change)
        {
            SSQCPlayerState ps = new SSQCPlayerState
            {
                GameID = psc.GameID,
                GameTime = psc.GameTime,
                EventType = psc.EventType,
                EventChange = change,
                TF_ID = psc.Player.TF_ID
            };

            await _context.AddAsync(ps);
            
            return await _context.SaveChangesAsync();
        }
    }
}