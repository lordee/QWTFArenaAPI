using System.Collections.Generic;
using System.Threading.Tasks;
using qwtfarena.Domain.Models;
using qwtfarena.Domain.Services;
using qwtfarena.Domain.Repositories;

namespace qwtfarena.Services
{
    public class SSQCStatsService : ISSQCStatsService
    {
        private readonly ISSQCStatsRepository _SSQCStatsRepository;

        public SSQCStatsService(ISSQCStatsRepository SSQCStatsRepository)
        {
            this._SSQCStatsRepository = SSQCStatsRepository;
        }

        public async Task<int> GameStateChange(GameStateChange gsc)
        { 
            // submit data
            switch (gsc.EventType.ToLower())
            {
                case "st_gamestart":
                    return await _SSQCStatsRepository.GameStart(gsc);
                default:
                    return await _SSQCStatsRepository.GameStateChange(gsc.GameID, gsc.GameTime, gsc.EventType, gsc.Initiator);
            }
        }

        public async Task<int> PlayerStateChange(PlayerStateChange psc)
        { 
            // TODO update players table for new players connecting etc
            string change = "";
            switch (psc.EventType.ToLower())
            {
                case "st_changename":
                    change = psc.Player.Name;
                    break;
                case "st_changeteam":
                    change = psc.Player.Team.ToString();
                    break;
                case "st_changeclass":
                    change = psc.Player.Class.ToString();
                    break;
                default:
                    change = "1";
                    break;
            }

            // submit to change tracking table
            return await _SSQCStatsRepository.PlayerStateChange(psc, change);
        }

        public async Task<int> Shoot(Shoot s)
        { 
            // submit data
            return await _SSQCStatsRepository.Shoot(s);
        }

        public async Task<int> Damage(GameDamage d)
        { 
            // submit data
            return await _SSQCStatsRepository.Damage(d);
        }

        public async Task<int> PlayerAction(PlayerAction pa)
        { 
            return await _SSQCStatsRepository.PlayerAction(pa);
        }

        public async Task<int> ScoreUpdate(ScoreUpdate su)
        { 
            return await _SSQCStatsRepository.ScoreUpdate(su);
        }
    }
}