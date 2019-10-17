using Newtonsoft.Json;


namespace Farmacity.FCDM.BackOffice.Entities.Enum
{
    [JsonConverter(typeof(GenericEnumConverter))]
    public enum InternalUserStatus
    {
        Disabled = 0,
        Enabled = 1 
    }
}
