using SportsLeagueManagement.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SportsLeagueManagement.Services
{
    public interface IPlayerService
    {
        Task<IEnumerable<Player>> GetAllPlayersAsync();
        Task<Player> GetPlayerByIdAsync(int id);
        Task AddPlayerAsync(Player player);
        Task UpdatePlayerAsync(Player player);
        Task DeletePlayerAsync(int id);
    }
}