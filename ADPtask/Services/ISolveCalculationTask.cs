using ADPtask.Models;

namespace ADPtask.Services
{
    public interface ISolveCalculationTask
    {
        dynamic Solve(CalculationTask calculationTask);
    }
}
