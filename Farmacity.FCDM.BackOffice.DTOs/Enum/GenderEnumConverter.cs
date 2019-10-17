using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace Farmacity.FCDM.BackOffice.DTOs.Enum
{
    public class GenderEnumConverter : StringEnumConverter
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (string.IsNullOrEmpty(reader.Value.ToString()))
                return Gender.Unspecified;

            return base.ReadJson(reader, objectType, existingValue, serializer);
        }
    }
}
