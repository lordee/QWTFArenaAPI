using System.Collections.Generic;
using System.Threading.Tasks;
using qwtfarena.Domain.Models;

namespace qwtfarena.Domain.Repositories
{
    public interface ISSQCStatsRepository
    {
        Task<int> GameStateChange(int gameid, float gametime, string eventtype, string initiator);
        Task<int> GameStart(GameStateChange gsc);
        
        Task<int> PlayerStateChange(PlayerStateChange psc, string change);
        Task<int> Shoot(Shoot s);
        Task<int> Damage(GameDamage d);
        Task<int> PlayerAction(PlayerAction pa);
        Task<int> ScoreUpdate(ScoreUpdate su);
    }
}