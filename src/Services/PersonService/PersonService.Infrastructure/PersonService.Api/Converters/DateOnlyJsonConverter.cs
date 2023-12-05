using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PersonService.Api.Converters;

/// <summary>
/// Конвертер для DateOnly
/// </summary>
public class DateOnlyJsonConverter : JsonConverter<DateOnly>
{
    /// <summary>
    /// Десериализация 
    /// </summary>
    /// <param name="reader">Представляет JSON-данные</param>
    /// <param name="typeToConvert">Type целевого типа</param>
    /// <param name="options">Настройки сериализации</param>
    /// <returns></returns>
    public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return DateOnly.FromDateTime(reader.GetDateTime());
    }

    /// <summary>
    /// Сериализация
    /// </summary>
    /// <param name="writer">Представляет целевой JSON документ</param>
    /// <param name="value">DateOnly для сериализации</param>
    /// <param name="options">Настройки сериализации</param>
    public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
    {
        var isoDate = value.ToString("O");
        writer.WriteStringValue(isoDate);
    }
}