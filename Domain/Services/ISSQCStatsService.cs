using System.Collections.Generic;
using System.Threading.Tasks;
using qwtfarena.Domain.Models;

namespace qwtfarena.Domain.Services
{
    public interface ISSQCStatsService
    {
        Task<int> GameStateChange(GameStateChange gsc);
    }
}