using SportsLeagueManagement.Models;
using SportsLeagueManagement.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SportsLeagueManagement.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IRepository<Player> _playerRepository;

        public PlayerService(IRepository<Player> playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public async Task<IEnumerable<Player>> GetAllPlayersAsync()
        {
            return await _playerRepository.GetAllAsync();
        }

        public async Task<Player> GetPlayerByIdAsync(int id)
        {
            return await _playerRepository.GetByIdAsync(id);
        }

        public async Task AddPlayerAsync(Player player)
        {
            await _playerRepository.AddAsync(player);
        }

        public async Task UpdatePlayerAsync(Player player)
        {
            await _playerRepository.UpdateAsync(player);
        }

        public async Task DeletePlayerAsync(int id)
        {
            await _playerRepository.DeleteAsync(id);
        }
    }
}