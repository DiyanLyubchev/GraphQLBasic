using System.Text.Json.Serialization;

namespace GraphQL.Model
{
    public class CarInput
    {
        [JsonPropertyName("carModel")]
        public string CarModel { get; set; }

        [JsonPropertyName("carBrand")]
        public string CarBrand { get; set; }
    }
}
