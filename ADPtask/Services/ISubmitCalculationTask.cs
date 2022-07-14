using ADPtask.Models;

namespace ADPtask.Services
{
    public interface ISubmitCalculationTask
    {
        Task<SubmitResponse> SubmitAsync(CalculationTaskResult calculationTaskResult);
    }
}
