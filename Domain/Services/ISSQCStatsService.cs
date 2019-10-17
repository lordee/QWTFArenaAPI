using System.Collections.Generic;
using System.Threading.Tasks;
using qwtfarena.Domain.Models;

namespace qwtfarena.Domain.Services
{
    public interface ISSQCStatsService
    {
        Task<int> GameStateChange(GameStateChange gsc);
        Task<int> PlayerStateChange(PlayerStateChange psc);
        Task<int> Shoot(Shoot s);
    }
}