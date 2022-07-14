using ADPtask.Models;

namespace ADPtask.Services
{
    public class CalculationTaksService : ICalculationTaksService
    {
        private readonly IGetCalculationTaskService _getCalculationTaskService;
        private readonly ISolveCalculationTask _solveCalculationTask;
        private readonly ISubmitCalculationTask _submitCalculationTask;
        public CalculationTaksService(IGetCalculationTaskService getCalculationTaskService, ISolveCalculationTask solveCalculationTask, ISubmitCalculationTask submitCalculationTask)
        {
            _getCalculationTaskService = getCalculationTaskService;
            _solveCalculationTask = solveCalculationTask;
            _submitCalculationTask = submitCalculationTask;
        }
        public async Task<CalculationTaskResult> CalculateTaskAsync()
        {
            var calcTaskResult = new CalculationTaskResult();
            calcTaskResult.CalculationTask = await _getCalculationTaskService.GetAsync();
            calcTaskResult.Result = _solveCalculationTask.Solve(calcTaskResult.CalculationTask);
            calcTaskResult.SubmitResponse = await _submitCalculationTask.SubmitAsync(calcTaskResult);
            return calcTaskResult;
        }
    }
}
