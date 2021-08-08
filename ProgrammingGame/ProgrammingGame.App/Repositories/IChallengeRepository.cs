using ProgrammingGame.App.DTO;
using ProgrammingGame.App.Models;
using System.Collections.Generic;

namespace ProgrammingGame.App.Repositories
{
    public interface IChallengeRepository
    {
        IEnumerable<Task> GetTasks();
        Task GetTask(int taskId);
        void AddEntry(EntryDto entry, TaskSubmitResultDto result);
        void Save();
    }
}
