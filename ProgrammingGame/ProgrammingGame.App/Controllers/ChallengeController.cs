using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProgrammingGame.App.DTO;
using ProgrammingGame.App.Repositories;
using ProgrammingGame.App.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingGame.App.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChallengeController : ControllerBase
    {
        private readonly ILogger<ChallengeController> _logger;
        private readonly IChallengeService _service;
        private readonly IChallengeRepository _repo;

        public ChallengeController(ILogger<ChallengeController> logger, IChallengeService service, IChallengeRepository repo)
        {
            _logger = logger;
            _service = service;
            _repo = repo;
        }

        private static readonly string[] Summaries = new[]
                {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet]
        public IActionResult Get()
        {
            var rng = new Random();
            var items = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();

            return Ok(items);
        }

        [HttpPost]
        [Route("submitTask")]
        public async Task<IActionResult> SubmitTask([FromBody] EntryDto entry)
        {
            var task = _repo.GetTask(entry.TaskId);
            var result = await _service.SubmitTaskAsync(entry.Solution);

            _repo.AddEntry(entry, result);
            _repo.Save();

            return Ok(new
            {
                isSolved = result.Output == task.Solution,
                time = result.Time,
                participantName = entry.ParticipantName
            });
        }

        [HttpGet]
        [Route("tasks")]
        public IActionResult GetTasks()
        {
            var tasks = _repo
                .GetTasks()
                .Select(t => new TaskDto { TaskId = t.TaskId, Name = t.Name, Description = t.Description });

            return Ok(tasks);
        }
    }
}
