using Newtonsoft.Json;

namespace BancoDeAlimentos.DTOs.Enum
{
    [JsonConverter(typeof(GenderEnumConverter))]
    public enum Gender
    {
        Male = 0,
        Female = 1,
        Unspecified = 2
    }
}
