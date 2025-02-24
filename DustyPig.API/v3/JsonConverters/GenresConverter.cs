using DustyPig.API.v3.MPAA;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DustyPig.API.v3.JsonConverters;

internal class GenresConverter : JsonConverter<Genres>
{
    public override Genres Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Number)
            return (Genres)reader.GetInt64();

        if (reader.TokenType == JsonTokenType.String)
        {
            string s = reader.GetString();
            if (long.TryParse(s, out long ret))
                return (Genres)ret;
        }

        throw new Exception("Unable to parse json");
    }

    public override void Write(Utf8JsonWriter writer, Genres value, JsonSerializerOptions options)
    {
        writer.WriteNumberValue((long)value);
    }
}
