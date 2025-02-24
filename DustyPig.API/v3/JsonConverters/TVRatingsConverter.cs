using DustyPig.API.v3.MPAA;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DustyPig.API.v3.JsonConverters;

internal class TVRatingsConverter : JsonConverter<TVRatings>
{
    public override TVRatings Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Number)
            return (TVRatings)reader.GetInt32();

        if (reader.TokenType == JsonTokenType.String)
        {
            string s = reader.GetString();
            if (int.TryParse(s, out int ret))
                return (TVRatings)ret;

            return RatingsUtils.ToTVRatings(s);
        }

        throw new Exception("Unable to parse json");
    }

    public override void Write(Utf8JsonWriter writer, TVRatings value, JsonSerializerOptions options)
    {
        writer.WriteNumberValue((int)value);
    }
}
