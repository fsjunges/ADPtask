using ADPtask.Models;

namespace ADPtask.Services
{
    public interface IGetCalculationTaskService
    {
        Task<CalculationTask> GetAsync();
    }
}
