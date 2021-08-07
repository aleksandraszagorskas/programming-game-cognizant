using NUnit.Framework;
using ProgrammingGame.App.Services;
using System.Threading.Tasks;

namespace ProgrammingGame.Test.Services
{
    public class ChallengeServiceTest
    {
        private ChallengeService _service;

        [SetUp]
        public void Setup()
        {
            _service = new ChallengeService();
        }

        [Test]
        public async Task SubmitTask_ValidData_()
        {
            //Arrange
            //Act
            var response = await _service.SubmitTask();

            //Assert
            Assert.NotNull(response);
            Assert.True(response.IsSuccessStatusCode);
        }
    }
}