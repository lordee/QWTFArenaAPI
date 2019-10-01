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

        public async Task<int> GameStatusChange(int gameid, string servername, float gametime, string eventtype, string map, string initiator)
        { 
            // submit data
            switch (eventtype.ToLower())
            {
                case "gamestart":
                    return await _SSQCStatsRepository.GameStart(servername, gametime, eventtype, map, initiator);
                default:
                    return await _SSQCStatsRepository.GameStatusChange(gameid, gametime, eventtype, initiator);

            }
        }
    }
}