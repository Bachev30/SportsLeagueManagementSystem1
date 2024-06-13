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
    public class LeaguesController : ControllerBase
    {
        private readonly ILeagueService _leagueService;
        private readonly IMapper _mapper;

        public LeaguesController(ILeagueService leagueService, IMapper mapper)
        {
            _leagueService = leagueService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LeagueViewModel>>> GetLeagues()
        {
            var leagues = await _leagueService.GetAllLeaguesAsync();
            return Ok(_mapper.Map<IEnumerable<LeagueViewModel>>(leagues));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LeagueViewModel>> GetLeague(int id)
        {
            var league = await _leagueService.GetLeagueByIdAsync(id);
            if (league == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<LeagueViewModel>(league));
        }

        [HttpPost]
        public async Task<ActionResult<LeagueViewModel>> PostLeague(LeagueViewModel leagueViewModel)
        {
            var league = _mapper.Map<League>(leagueViewModel);
            await _leagueService.AddLeagueAsync(league);
            return CreatedAtAction(nameof(GetLeague), new { id = league.LeagueId }, _mapper.Map<LeagueViewModel>(league));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutLeague(int id, LeagueViewModel leagueViewModel)
        {
            if (id != leagueViewModel.LeagueId)
            {
                return BadRequest();
            }

            var league = _mapper.Map<League>(leagueViewModel);
            await _leagueService.UpdateLeagueAsync(league);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLeague(int id)
        {
            await _leagueService.DeleteLeagueAsync(id);
            return NoContent();
        }
    }
}