using ADPtask.Converters;
using System.Text.Json.Serialization;

namespace ADPtask.Models
{
    public class CalculationTaskResult
    {
        public CalculationTask CalculationTask { get; set; }

        [JsonConverter(typeof(CustomBigIntegerJsonConverter))] 
        public dynamic Result { get; set; }
        public SubmitResponse SubmitResponse { get; set; }
    }
}
