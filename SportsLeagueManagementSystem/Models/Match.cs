using System;
using System.ComponentModel.DataAnnotations;

namespace SportsLeagueManagement.Models
{
    public class Match
    {
        public int MatchId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Location { get; set; }

        public int TeamAId { get; set; }
        public int TeamBId { get; set; }

        public string Score { get; set; }

        public Team TeamA { get; set; }
        public Team TeamB { get; set; }
    }
}
