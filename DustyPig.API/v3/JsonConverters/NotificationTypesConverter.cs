using DustyPig.API.v3.Models;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DustyPig.API.v3.JsonConverters;

internal class NotificationTypesConverter : JsonConverter<NotificationTypes>
{
    public override NotificationTypes Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Number)
            return (NotificationTypes)reader.GetInt32();

        if (reader.TokenType == JsonTokenType.String)
        {
            string s = reader.GetString();
            if (int.TryParse(s, out int ret))
                return (NotificationTypes)ret;

            foreach (NotificationTypes value in Enum.GetValues(typeof(NotificationTypes)))
                if (value.ToString().ICEquals(s))
                    return value;
        }

        throw new Exception("Unable to parse json");
    }

    public override void Write(Utf8JsonWriter writer, NotificationTypes value, JsonSerializerOptions options)
    {
        writer.WriteNumberValue((int)value);
    }
}
