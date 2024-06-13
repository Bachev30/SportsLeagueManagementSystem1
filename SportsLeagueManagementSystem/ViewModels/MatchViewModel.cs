using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SportsLeagueManagement.ViewModels
{
    public class LeagueViewModel
    {
        public int LeagueId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Sport { get; set; }

        public ICollection<TeamViewModel> Teams { get; set; }
    }
}