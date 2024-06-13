using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SportsLeagueManagement.Models;
using SportsLeagueManagement.Services;
using SportsLeagueManagement.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SportsLeagueManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayerService _playerService;
        private readonly IMapper _mapper;

        public PlayersController(IPlayerService playerService, IMapper mapper)
        {
            _playerService = playerService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlayerViewModel>>> GetPlayers()
        {
            var players = await _playerService.GetAllPlayersAsync();
            return Ok(_mapper.Map<IEnumerable<PlayerViewModel>>(players));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PlayerViewModel>> GetPlayer(int id)
        {
            var player = await _playerService.GetPlayerByIdAsync(id);
            if (player == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<PlayerViewModel>(player));
        }

        [HttpPost]
        public async Task<ActionResult<PlayerViewModel>> PostPlayer(PlayerViewModel playerViewModel)
        {
            var player = _mapper.Map<Player>(playerViewModel);
            await _playerService.AddPlayerAsync(player);
            return CreatedAtAction(nameof(GetPlayer), new { id = player.PlayerId }, _mapper.Map<PlayerViewModel>(player));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayer(int id, PlayerViewModel playerViewModel)
        {
            if (id != playerViewModel.PlayerId)
            {
                return BadRequest();
            }

            var player = _mapper.Map<Player>(playerViewModel);
            await _playerService.UpdatePlayerAsync(player);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayer(int id)
        {
            await _playerService.DeletePlayerAsync(id);
            return NoContent();
        }
    }
}
