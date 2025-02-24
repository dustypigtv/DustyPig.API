using DustyPig.API.v3.MPAA;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DustyPig.API.v3.JsonConverters;

internal class MovieRatingsConverter : JsonConverter<MovieRatings>
{
    public override MovieRatings Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Number)
            return (MovieRatings)reader.GetInt32();

        if (reader.TokenType == JsonTokenType.String)
        {
            string s = reader.GetString();
            if (int.TryParse(s, out int ret))
                return (MovieRatings)ret;

            return RatingsUtils.ToMovieRatings(s);
        }

        throw new Exception("Unable to parse json");
    }

    public override void Write(Utf8JsonWriter writer, MovieRatings value, JsonSerializerOptions options)
    {
        writer.WriteNumberValue((int)value);
    }
}
