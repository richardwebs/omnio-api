using NUnit.Framework;
using Omnia.DataAccess.Repositories;
using System;

namespace Omnia.DataAccess.IntegrationTests.RepositoryTests
{
    [TestFixture]
    public class PlayerRepositoryTests
    {
        private readonly IPlayerRepository _repository;

        public PlayerRepositoryTests()
        {
            _repository = new PlayerRepository();
        }

        [Test]
        public void GetCountScoreHigherThan_Returns_Value()
        {
            // execute
            var result = _repository.GetCountScoreHigherThan(2).Result;
            // assert
            Assert.AreEqual(2, result);
        }

        [Test]
        public void UpdateScore_Returns_Void()
        {
            // setup
            var playerId = new Guid("066ee165-4125-464f-87aa-0a6a08e4f909");
            const int newScore = 1;
            // execute
            _repository.UpdateScore(playerId, newScore).Wait(0);
        } 
    }
}
