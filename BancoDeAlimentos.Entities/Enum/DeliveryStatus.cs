using Newtonsoft.Json;


namespace BancoDeAlimentos.Entities.Enum
{
    [JsonConverter(typeof(GenericEnumConverter))]
    public enum DeliveryStatus
    {
        Pending = 0,
        Done = 1 
    }
}
