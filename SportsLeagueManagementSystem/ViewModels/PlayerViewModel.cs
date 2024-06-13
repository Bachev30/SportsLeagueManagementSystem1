using System.ComponentModel.DataAnnotations;

namespace SportsLeagueManagement.ViewModels
{
    public class PlayerViewModel
    {
        public int PlayerId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public int TeamId { get; set; }
        public string Position { get; set; }
    }
}