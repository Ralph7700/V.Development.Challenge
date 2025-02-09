using System.Text.Json.Serialization;

namespace VeerBackend.Domain.Enums;

// this will ensure that this enum gets automatically serialized and deserialized into its display name when converting it into Json
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Gender
{
    Male,
    Female
}