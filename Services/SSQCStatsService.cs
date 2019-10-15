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
            // submit data
            return await _SSQCStatsRepository.PlayerStateChange(psc);
        }
    }
}