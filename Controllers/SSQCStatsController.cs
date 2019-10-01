using Microsoft.AspNetCore.Mvc;
using qwtfarena.Domain.Models;
using qwtfarena.Domain.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace qwtfarena.Controllers
{
    [Route("/api/[controller]")]
    public class SSQCStatsController : Controller
    {
        private readonly ISSQCStatsService _statsService;
        
        public SSQCStatsController(ISSQCStatsService statsService)
        {
            _statsService = statsService;   
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<int> GameStatusChange(int gameid, string servername, float gametime, string eventtype, string map, string initiator)
        {
            var resp = await _statsService.GameStatusChange(gameid, servername, gametime, eventtype, map, initiator);
            return resp;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<int> GameStatusTest(int gameid)
        {
            return gameid;
        }

        [HttpGet]
        public async Task<int> Get()
        {
            return 7;
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<int> GetTest()
        {
            return 7999;
        }
    }
}