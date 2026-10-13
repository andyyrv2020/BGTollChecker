using System.Text.Json.Serialization;

namespace BGTollChecker.Models
{
    public class BGTollApiResponse
    {
        [JsonPropertyName("vignette")]
        public List<VignetteInfo> Vignettes { get; set; } = new();

        [JsonPropertyName("ok")]
        public bool Ok { get; set; }
    }

    public class VignetteInfo
    {
        public string LicensePlateNumber { get; set; } = "";
        public string Country { get; set; } = "";
        public bool Exempt { get; set; }
        public string VignetteNumber { get; set; } = "";
        public string VehicleClass { get; set; } = "";
        [JsonPropertyName("emissionsClass")]
        public string EmissionsClass { get; set; } = ""; public string ValidityDateFromFormated { get; set; } = "";
        public string ValidityDateToFormated { get; set; } = "";
        public decimal Price { get; set; }
        public string Currency { get; set; } = "";
        public string Status { get; set; } = "";
        public bool StatusBoolean { get; set; }
        public string VehicleType { get; set; } = "";
    }
}
