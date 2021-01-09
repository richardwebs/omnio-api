using Omnia.DataAccess.Entities;
using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Omnia.DataAccess.Repositories
{
    public interface IPlayerRepository
    {
        Task<int> GetCountScoreHigherThan(int minScore);
        Task UpdateScore(Guid playerId, int newScore);
    }
    public class PlayerRepository : IPlayerRepository
    {
        private const string JsonFilePath = @"data.json";
        public async Task<int> GetCountScoreHigherThan(int minScore)
        {
            var json = await File.ReadAllTextAsync(JsonFilePath);
            var players = JsonSerializer.Deserialize<Player[]>(json);
            return players.Count(x => x.Score > minScore);
        }

        public async Task UpdateScore(Guid playerId, int newScore)
        {
            var json = await File.ReadAllTextAsync(JsonFilePath);
            var players = JsonSerializer.Deserialize<Player[]>(json);
            var player = players.Single(x => x.PlayerId == playerId);
            player.Score = newScore;
            json = JsonSerializer.Serialize(players);
            await File.WriteAllTextAsync(JsonFilePath, json);
        }
    }
}
