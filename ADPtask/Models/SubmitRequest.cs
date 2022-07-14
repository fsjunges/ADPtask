using ADPtask.Converters;
using System.Text.Json.Serialization;

namespace ADPtask.Models
{
    public class SubmitRequest
    {
        public Guid id { get; set; }
        [JsonConverter(typeof(CustomBigIntegerJsonConverter))]
        public dynamic result { get; set; }
    }
}
