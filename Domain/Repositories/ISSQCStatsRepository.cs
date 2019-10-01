using System.Collections.Generic;
using System.Threading.Tasks;
using qwtfarena.Domain.Models;

namespace qwtfarena.Domain.Repositories
{
    public interface ISSQCStatsRepository
    {
         Task<int> GameStatusChange(int gameid, float gametime, string eventtype, string initiator);

         Task<int> GameStart(string servername, float gametime, string eventtype, string map, string initiator);
    }
}