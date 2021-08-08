using ProgrammingGame.App.DTO;
using ProgrammingGame.App.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProgrammingGame.App.Repositories
{
    public class ChallengeRepository : IChallengeRepository
    {
        private EntryContext _context;

        public ChallengeRepository(EntryContext context)
        {
            _context = context;
        }

        public void AddEntry(EntryDto entry, TaskSubmitResultDto result)
        {
            var task = GetTask(entry.TaskId);
            _context.Entries.Add(new Entry { ParticipantName = entry.ParticipantName, SolutionCode = entry.Solution, Task = task, IsSolved = result.Output == task.Solution, Time = result.Time });
        }

        public Task GetTask(int taskId)
        {
            return _context.Tasks.Single(t => t.TaskId == taskId);
        }

        public IEnumerable<Task> GetTasks()
        {
            return _context.Tasks;
        }

        public void Save()
        {
            _context.SaveChangesAsync();
        }
    }
}
