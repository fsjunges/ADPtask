using System.Numerics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ADPtask.Converters
{
    public class CustomBigIntegerJsonConverter : JsonConverter<object>
    {
        public override object Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return reader.TokenType switch
            {
                JsonTokenType.Number => new BigInteger(reader.GetInt64()),
                _ => JsonDocument.ParseValue(ref reader).RootElement.Clone()
            };
        }

        public override void Write(Utf8JsonWriter writer, object value, JsonSerializerOptions options)
        {
            if (value is BigInteger)
            {
                writer.WriteRawValue(value.ToString()!, skipInputValidation: true);
            }
            else
            {
                JsonSerializer.Serialize(writer, value, value.GetType(), options);
            }
        }
    }
}
