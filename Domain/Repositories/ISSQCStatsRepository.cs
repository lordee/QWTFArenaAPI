using System.Collections.Generic;
using System.Threading.Tasks;
using qwtfarena.Domain.Models;

namespace qwtfarena.Domain.Repositories
{
    public interface ISSQCStatsRepository
    {
        Task<int> GameStateChange(int gameid, float gametime, string eventtype, string initiator);
        Task<int> GameStart(GameStateChange gsc);
        
        Task<int> PlayerStateChange(PlayerStateChange psc);
    }
}