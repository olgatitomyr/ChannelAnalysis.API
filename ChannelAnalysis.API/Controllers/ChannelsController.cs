using Microsoft.AspNetCore.Mvc;
using ChannelAnalysis.API.Data;
using Microsoft.EntityFrameworkCore;
using ChannelAnalysis.API.Models;

namespace ChannelAnalysis.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChannelsController : ControllerBase
    {
        private readonly ILogger<ChannelsController> _logger;
        private readonly ChannelAnalysisDbContext _context;

        public ChannelsController(ILogger<ChannelsController> logger, ChannelAnalysisDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllChannels()
        {
            var channels = await _context.Channel
                .Include(c => c.Statistics)
                .Include(c => c.ProrussianCoefficient)
                .ToListAsync();

            return Ok(channels);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetChannelById(long id)
        {
            var channel = await _context.Channel
                .Include(c => c.Statistics)
                .Include(c => c.ProrussianCoefficient)
                .FirstOrDefaultAsync(c => c.Id == id);

            return channel is null ? NotFound() : Ok(channel);
        }

        //[HttpPost]
        //public async Task<IActionResult> AddChannel(string channelName)
        //{
        //    var channel = new Channel { ChannelName = channelName };
        //    channel = _context.Channel.Add(channel).Entity;
        //    _context.AnalysisQueue.Add(new AnalysisQueue { ChannelId = channel.Id });
        //    await _context.SaveChangesAsync();

        //    return Ok();
        //}
    }
}