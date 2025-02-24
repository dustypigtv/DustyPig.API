using DustyPig.API.v3.Models;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DustyPig.API.v3.JsonConverters;

internal class RequestStatusConverter : JsonConverter<RequestStatus>
{
    public override RequestStatus Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Number)
            return (RequestStatus)reader.GetInt32();

        if (reader.TokenType == JsonTokenType.String)
        {
            string s = reader.GetString();
            if (int.TryParse(s, out int ret))
                return (RequestStatus)ret;

            foreach (RequestStatus value in Enum.GetValues(typeof(RequestStatus)))
                if (value.ToString().ICEquals(s))
                    return value;
        }

        throw new Exception("Unable to parse json");
    }

    public override void Write(Utf8JsonWriter writer, RequestStatus value, JsonSerializerOptions options)
    {
        writer.WriteNumberValue((int)value);
    }
}
