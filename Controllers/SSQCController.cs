using System.Collections.Generic;

namespace qwtfarena.Controllers
{
    [Route("/api/[controller]")]
    public class SSQCController : Controller
    {
        [HttpGet]
        public async Task<IEnumerable<>> GetSubmitGameStart(string packetID, string time, string serverID, string gameType, string mapName, List<Player> players)
        {
            // start game
                

            return gameID;
        }

        [HttpGet]
        public async Task<IEnumerable<>> GetSubmitGameEnd(string packetID, string time, string serverID, string gameID)
        {
            // end game

            
        }

        [HttpGet]
        public async Task<IEnumerable<>> GetSubmitChat(string packetID, string time, string serverID, string gameID, string playerID, string message)
        {            
        }

        [HttpGet]
        public async Task<IEnumerable<>> GetSubmitPlayerStatus(string packetID, string time, string serverID, string gameID, Player player, string status)
        {            
            // join, leave, change team, change name etc
        }

        [HttpGet]
        public async Task<IEnumerable<>> GetSubmitGoalTouch(string packetID, string time, string serverID, string gameID, string playerID, string gametime)
        {             
        }

        [HttpGet]
        public async Task<IEnumerable<>> GetSubmitGoalFumble(string packetID, string time, string serverID, string gameID, string playerID, string gametime)
        {

        }

        [HttpGet]
        public async Task<IEnumerable<>> GetSubmitShoot(string packetID, string time, string serverID, string gameID, string playerID, string weaponType, string gametime)
        {

        }

    }
}