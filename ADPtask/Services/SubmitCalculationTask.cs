using ADPtask.Models;
using ADPtask.Options;
using Microsoft.Extensions.Options;

namespace ADPtask.Services
{
    public class SubmitCalculationTask : ISubmitCalculationTask
    {
        private readonly HttpClient _httpClient;
        private readonly ADPtaskApiOptions _options;
        public SubmitCalculationTask(HttpClient httpClient, IOptions<ADPtaskApiOptions> options)
        {
            _httpClient = httpClient;
            _options = options.Value;
        }
        public async Task<SubmitResponse> SubmitAsync(CalculationTaskResult calculationTaskResult)
        {
            var uri = new Uri($"{_options.ApiUrl}{_options.SubmitTaskEndpoint}");

            var submitResponse = new SubmitResponse();

            var submitRequest = new SubmitRequest
            {
                id = calculationTaskResult.CalculationTask.id,
                result = calculationTaskResult.Result
            };

            var response = await _httpClient.PostAsJsonAsync(uri, submitRequest);
            var responseContent = await response.Content.ReadAsStringAsync();

            submitResponse.StatusCode = response.StatusCode;
            submitResponse.Message = responseContent;

            return submitResponse;
        }
    }
}