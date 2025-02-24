using DustyPig.API.v3.Models;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DustyPig.API.v3.JsonConverters;

internal class TMDB_MediaTypesConverter : JsonConverter<TMDB_MediaTypes>
{
    public override TMDB_MediaTypes Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Number)
            return (TMDB_MediaTypes)reader.GetInt32();

        if (reader.TokenType == JsonTokenType.String)
        {
            string s = reader.GetString();
            if (int.TryParse(s, out int ret))
                return (TMDB_MediaTypes)ret;

            foreach (TMDB_MediaTypes value in Enum.GetValues(typeof(TMDB_MediaTypes)))
                if (value.ToString().ICEquals(s))
                    return value;
        }

        throw new Exception("Unable to parse json");
    }

    public override void Write(Utf8JsonWriter writer, TMDB_MediaTypes value, JsonSerializerOptions options)
    {
        writer.WriteNumberValue((int)value);
    }
}
