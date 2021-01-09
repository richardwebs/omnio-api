using NUnit.Framework;
using Omnia.WebAPI.Models;
using System;
using System.Linq;

namespace Omnia.WebAPI.UnitTests.ModelTests
{
    [TestFixture]
    public class UpdateScoreTests
    {
        private readonly IValidation _validation;

        public UpdateScoreTests()
        {
            _validation = new Validation();
        }

        [Test]
        public void Valid_Model()
        {
            // setup
            var model = new UpdateScoreModel{ PlayerId = Guid.NewGuid(), NewScore = 0 };
            // execute
            var success = _validation.IsModelValid(model);
            // assert
            Assert.IsTrue(success);
        }

        [Test]
        public void Invalid_Model()
        {
            // setup
            var model = new UpdateScoreModel { PlayerId = null, NewScore = null };
            // execute
            var success = _validation.IsModelValid(model);
            var results = _validation.GetValidationResults(model);
            // assert
            Assert.IsFalse(success);
            Assert.AreEqual(2, results.Count);
            foreach (var result in results) Console.WriteLine("{0}: {1}", result.MemberNames.First(), result.ErrorMessage);
        }
    }
}
