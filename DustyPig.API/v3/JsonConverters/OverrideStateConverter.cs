using DustyPig.API.v3.Models;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DustyPig.API.v3.JsonConverters;

internal class OverrideStateConverter : JsonConverter<OverrideState>
{
    public override OverrideState Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Number)
            return (OverrideState)reader.GetInt32();

        if (reader.TokenType == JsonTokenType.String)
        {
            string s = reader.GetString();
            if (int.TryParse(s, out int ret))
                return (OverrideState)ret;

            foreach (OverrideState value in Enum.GetValues(typeof(OverrideState)))
                if (value.ToString().ICEquals(s))
                    return value;
        }

        throw new Exception("Unable to parse json");
    }

    public override void Write(Utf8JsonWriter writer, OverrideState value, JsonSerializerOptions options)
    {
        writer.WriteNumberValue((int)value);
    }
}
