using Newtonsoft.Json;


namespace BancoDeAlimentos.Entities.Enum
{
    [JsonConverter(typeof(GenericEnumConverter))]
    public enum InternalUserStatus
    {
        Disabled = 0,
        Enabled = 1 
    }
}
