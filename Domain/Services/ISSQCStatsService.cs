using System.Collections.Generic;
using System.Threading.Tasks;
using qwtfarena.Domain.Models;

namespace qwtfarena.Domain.Services
{
    public interface ISSQCStatsService
    {
        Task<int> GameStatusChange(int gameid, string servername, float gametime, string eventtype, string map, string initiator);
    }
}