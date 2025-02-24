using DustyPig.API.v3.Models;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DustyPig.API.v3.JsonConverters;

internal class OverrideRequestStatusConverter : JsonConverter<OverrideRequestStatus>
{
    public override OverrideRequestStatus Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Number)
            return (OverrideRequestStatus)reader.GetInt32();

        if (reader.TokenType == JsonTokenType.String)
        {
            string s = reader.GetString();
            if (int.TryParse(s, out int ret))
                return (OverrideRequestStatus)ret;

            foreach (OverrideRequestStatus value in Enum.GetValues(typeof(OverrideRequestStatus)))
                if (value.ToString().ICEquals(s))
                    return value;
        }

        throw new Exception("Unable to parse json");
    }

    public override void Write(Utf8JsonWriter writer, OverrideRequestStatus value, JsonSerializerOptions options)
    {
        writer.WriteNumberValue((int)value);
    }
}
