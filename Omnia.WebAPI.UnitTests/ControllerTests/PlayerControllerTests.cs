using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using Omnia.DataAccess.Repositories;
using Omnia.WebAPI.Controllers;
using Omnia.WebAPI.Models;
using System;


namespace Omnia.WebAPI.UnitTests.ControllerTests
{
    [TestFixture]
    public class PlayerControllerTests
    {
        private IPlayerController _controller;
        private Mock<IPlayerRepository> _repository;

        [SetUp]
        public void Setup()
        {
            _repository = new Mock<IPlayerRepository>();
            _controller = new PlayerController(new Mock<ILogger<PlayerController>>().Object, _repository.Object);
        }

        [Test]
        public void GetCountScoreHigherThan_Returns_Value()
        {
            // setup
            const int minScore = 0;
            const int returnValue = 0;
            _repository.Setup(x => x.GetCountScoreHigherThan(minScore)).ReturnsAsync(returnValue);
            // execute
            var result = _controller.GetCountScoreHigherThan(minScore).Result;
            // verify
            _repository.Verify(x => x.GetCountScoreHigherThan(minScore), Times.Once);
            // assert
            Assert.AreEqual(returnValue, result);
        }

        [Test]
        public void UpdateScore_Returns_Void()
        {
            // setup
            var playerId = Guid.NewGuid();
            const int newScore = 0;
            _repository.Setup(x => x.UpdateScore(playerId, newScore));
            // execute
            _controller.UpdateScore(new UpdateScoreModel { PlayerId = playerId, NewScore = newScore}).Wait(0);
            // verify
            _repository.Verify(x => x.UpdateScore(playerId, newScore), Times.Once);
        }
    }
}
