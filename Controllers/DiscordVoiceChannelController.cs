using Microsoft.AspNetCore.Mvc;
using qwtfarena.Domain.Models;
using qwtfarena.Domain.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace qwtfarena.Controllers
{
    [Route("/api/[controller]")]
    public class DiscordVoiceChannelsController : Controller
    {
        private readonly IDiscordVoiceChannelService _channelService;
        
        public DiscordVoiceChannelsController(IDiscordVoiceChannelService channelService)
        {
            _channelService = channelService;   
        }

        [HttpGet]
        public async Task<IEnumerable<DiscordVoiceChannel>> GetAllAsync()
        {
            var channels = await _channelService.ListAsync();
            return channels;
        }
    }
}