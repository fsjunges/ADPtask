using ADPtask.Models;

namespace ADPtask.Services
{
    public interface ICalculationTaksService
    {
        Task<CalculationTaskResult> CalculateTaskAsync();
    }
}
