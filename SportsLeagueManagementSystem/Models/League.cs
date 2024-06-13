using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SportsLeagueManagement.Models
{
    public class League
    {
        public int LeagueId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Sport { get; set; }

        public ICollection<Team> Teams { get; set; }
    }
}