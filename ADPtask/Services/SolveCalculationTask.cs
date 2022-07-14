using ADPtask.Models;
using System.Numerics;

namespace ADPtask.Services
{
    public class SolveCalculationTask : ISolveCalculationTask
    {
        private readonly IGetCalculationTaskService _getCalculationTaskService;
        public SolveCalculationTask(IGetCalculationTaskService getCalculationTaskService)
        {
            _getCalculationTaskService = getCalculationTaskService;
        }
        public dynamic Solve(CalculationTask calculationTask)
        {
            return calculationTask.operation switch
            {
                "addition" => BigInteger.Add(calculationTask.left, calculationTask.right),
                "subtraction" => BigInteger.Subtract(calculationTask.left, calculationTask.right),
                "multiplication" => BigInteger.Multiply(calculationTask.left, calculationTask.right),
                "division" => ((double)calculationTask.left / (double)calculationTask.right),
                "remainder" => BigInteger.Remainder(calculationTask.left, calculationTask.right),
                _ => throw new NotImplementedException(calculationTask.operation)
            };
        }
    }
}
