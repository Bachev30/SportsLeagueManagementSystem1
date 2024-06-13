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
    public class MatchesController : ControllerBase
    {
        private readonly IMatchService _matchService;
        private readonly IMapper _mapper;

        public MatchesController(IMatchService matchService, IMapper mapper)
        {
            _matchService = matchService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MatchViewModel>>> GetMatches()
        {
            var matches = await _matchService.GetAllMatchesAsync();
            return Ok(_mapper.Map<IEnumerable<MatchViewModel>>(matches));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MatchViewModel>> GetMatch(int id)
        {
            var match = await _matchService.GetMatchByIdAsync(id);
            if (match == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<MatchViewModel>(match));
        }

        [HttpPost]
        public async Task<ActionResult<MatchViewModel>> PostMatch(MatchViewModel matchViewModel)
        {
            var match = _mapper.Map<Match>(matchViewModel);
            await _matchService.AddMatchAsync(match);
            return CreatedAtAction(nameof(GetMatch), new { id = match.MatchId }, _mapper.Map<MatchViewModel>(match));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMatch(int id, MatchViewModel matchViewModel)
        {
            if (id != matchViewModel.MatchId)
            {
                return BadRequest();
            }

            var match = _mapper.Map<Match>(matchViewModel);
            await _matchService.UpdateMatchAsync(match);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMatch(int id)
        {
            await _matchService.DeleteMatchAsync(id);
            return NoContent();
        }
    }
}
