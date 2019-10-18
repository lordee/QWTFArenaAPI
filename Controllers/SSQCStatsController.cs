using Microsoft.AspNetCore.Mvc;
using qwtfarena.Domain.Models;
using qwtfarena.Domain.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;

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
        public async Task<int> GameStateChange([FromBody] GameStateChange gsc)
        {
            var resp = await _statsService.GameStateChange(gsc);
            return resp;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<int> PlayerStateChange([FromBody] PlayerStateChange psc)
        {
            var resp = await _statsService.PlayerStateChange(psc);
            return resp;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<int> Shoot([FromBody] Shoot s)
        {
            var resp = await _statsService.Shoot(s);
            return resp;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<int> Damage([FromBody] GameDamage d)
        {
            var resp = await _statsService.Damage(d);
            return resp;
        }

        // PlayerAction
        [Route("[action]")]
        [HttpPost]
        public async Task<int> PlayerAction([FromBody] PlayerAction pa)
        {
            var resp = await _statsService.PlayerAction(pa);
            return resp;
        }

        // ScoreUpdate
    }
}