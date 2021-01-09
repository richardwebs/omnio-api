using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Omnia.DataAccess.Repositories;
using Omnia.WebAPI.Models;

namespace Omnia.WebAPI.Controllers
{
    public interface IPlayerController
    {
        Task<int> GetCountScoreHigherThan(int minScore);
        Task UpdateScore(UpdateScoreModel model);
    }

    [ApiController]
    [Route("[controller]")]
    public class PlayerController : ControllerBase, IPlayerController
    {
        private readonly ILogger<PlayerController> _logger;
        private readonly IPlayerRepository _repository;

        public PlayerController(ILogger<PlayerController> logger, IPlayerRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet, Route("GetCountScoreHigherThan")]
        public async Task<int> GetCountScoreHigherThan(int minScore)
        {
            return await _repository.GetCountScoreHigherThan(minScore);
        }

        [HttpPatch, Route("UpdateScore")]
        public async Task UpdateScore(UpdateScoreModel model)
        {
            await _repository.UpdateScore(model.PlayerId.GetValueOrDefault(), model.NewScore.GetValueOrDefault());
        }
    }
}
