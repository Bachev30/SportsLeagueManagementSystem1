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
    public class TeamsController : ControllerBase
    {
        private readonly ITeamService _teamService;
        private readonly IMapper _mapper;

        public TeamsController(ITeamService teamService, IMapper mapper)
        {
            _teamService = teamService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeamViewModel>>> GetTeams()
        {
            var teams = await _teamService.GetAllTeamsAsync();
            return Ok(_mapper.Map<IEnumerable<TeamViewModel>>(teams));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TeamViewModel>> GetTeam(int id)
        {
            var team = await _teamService.GetTeamByIdAsync(id);
            if (team == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<TeamViewModel>(team));
        }

        [HttpPost]
        public async Task<ActionResult<TeamViewModel>> PostTeam(TeamViewModel teamViewModel)
        {
            var team = _mapper.Map<Team>(teamViewModel);
            await _teamService.AddTeamAsync(team);
            return CreatedAtAction(nameof(GetTeam), new { id = team.TeamId }, _mapper.Map<TeamViewModel>(team));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeam(int id, TeamViewModel teamViewModel)
        {
            if (id != teamViewModel.TeamId)
            {
                return BadRequest();
            }

            var team = _mapper.Map<Team>(teamViewModel);
            await _teamService.UpdateTeamAsync(team);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeam(int id)
        {
            await _teamService.DeleteTeamAsync(id);
            return NoContent();
        }
    }
}
