using ADPtask.Models;
using ADPtask.Options;
using Microsoft.Extensions.Options;

namespace ADPtask.Services
{
    public class GetCalculationTaskService : IGetCalculationTaskService
    {
        private readonly HttpClient _httpClient;
        private readonly ADPtaskApiOptions _options;
        public GetCalculationTaskService(HttpClient httpClient, IOptions<ADPtaskApiOptions> options)
        {
            _httpClient = httpClient;
            _options = options.Value;
        }
        public async Task<CalculationTask> GetAsync()
        {
            var uri = new Uri($"{_options.ApiUrl}{_options.GetTaskEndpoint}");

            var taskResponse = await _httpClient.GetAsync(uri);
            if (taskResponse.IsSuccessStatusCode)
            {
                var taskReadContent = await taskResponse.Content.ReadFromJsonAsync<CalculationTask>();
                return taskReadContent!;
            }
            else
            {
                return new CalculationTask();
            }
        }
    }
}
