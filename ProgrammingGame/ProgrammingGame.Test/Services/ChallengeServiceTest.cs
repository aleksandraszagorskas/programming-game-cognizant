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
            var solution = "Hello World!";
            var scriptString = @$"
                using System;
                class Program
                {{
                    static void Main(string[] args) {{
                        //Your code goes here
                        Console.WriteLine(""{solution}"");
                    }}
                }}
            ";

            //Act
            var result = await _service.SubmitTaskAsync(scriptString);

            //Assert
            Assert.NotNull(result);
            Assert.AreEqual(solution, result.Output);
        }
    }
}