#if !NET7_0_OR_GREATER
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DustyPig.API.v3.JsonConverters;

public class DateOnlyConverter : JsonConverter<DateOnly>
{
    public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (DateOnly.TryParse(reader.GetString(), out DateOnly dateOnly))
            return dateOnly;
        return default;
    }

    public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString("yyyy-MM-dd"));
    }
}
#endif