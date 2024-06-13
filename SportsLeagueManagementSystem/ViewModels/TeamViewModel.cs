using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SportsLeagueManagement.ViewModels
{
    public class TeamViewModel
    {
        public int TeamId { get; set; }

        [Required]
        public string Name { get; set; }

        public int LeagueId { get; set; }
        public ICollection<PlayerViewModel> Players { get; set; }
    }
}