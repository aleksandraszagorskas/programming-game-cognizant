using ProgrammingGame.App.DTO;
using System.Threading.Tasks;

namespace ProgrammingGame.App.Services
{
    public interface IChallengeService
    {
        Task<TaskSubmitResultDto> SubmitTaskAsync(string scriptString);
    }
}
