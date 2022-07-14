using ADPtask.Models;
using ADPtask.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ADPtask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculationTaskController : ControllerBase
    {
        private readonly ICalculationTaksService _calculationTaksService;
        public CalculationTaskController(ICalculationTaksService calculationTaksService)
        {
            _calculationTaksService = calculationTaksService;
        }

        [HttpGet]
        public async Task<ActionResult<CalculationTaskResult>> Get()
        {
            try
            {
                return await _calculationTaksService.CalculateTaskAsync();
            }
            catch (Exception ex)
            {
                return new ObjectResult(ex.Message) { StatusCode = (int)HttpStatusCode.InternalServerError };
            }
            
        }
    }
}
