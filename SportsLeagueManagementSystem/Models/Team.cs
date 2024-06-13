using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SportsLeagueManagement.Models
{
    public class Team
    {
        public int TeamId { get; set; }

        [Required]
        public string Name { get; set; }

        public int LeagueId { get; set; }
        public ICollection<Player> Players { get; set; }

        public League League { get; set; }
    }
}
