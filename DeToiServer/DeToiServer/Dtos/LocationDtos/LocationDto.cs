using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DeToiServer.Dtos.LocationDtos
{
    public class InputGeoCodeDto
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }

    public class LocationAddressResultDto
    {
        public string? Amenity { get; set; }
        public string? House_number { get; set; }
        public string? Road { get; set; }
        public string? Quarter { get; set; } // Phường
        public string? Village { get; set; } // Xã
        public string? Town { get; set; }
        public string? Suburb { get; set; } // Quận
        public string? City_district { get; set; } // Quận
        public string? County { get; set; } // Quận
        public string? City { get; set; } // Thành phố
        public string? State { get; set; } // Thành phố
        [JsonPropertyName("ISO3166-2-lvl4")] public string? IsoCode { get; set; }
        public int? Postcode { get; set; }
        public string? Country { get; set; }
        public string? Country_code { get; set; }
    }

    public class RevGeoCodeResponseDto
    {
        public double? Lat { get; set; }
        public double? Lon { get; set; }
        public string? Display_name { get; set; }
        public LocationAddressResultDto? Address { get; set; }
    }

    public class RevGeoCodeResultDto
    {
        public double Lat { get; set; }
        public double Lon { get; set; }
        public string? Display_name { get; set; } = string.Empty;

        public string? Amenity { get; set; }
        public string? House_number { get; set; }
        public string? Road { get; set; }

        public string Ward { get; set; } = string.Empty; // Phường - Xã, thị trấn
        public string District { get; set; } = string.Empty; // Quận - Huyện
        public string Province { get; set; } = string.Empty; // tỉnh - thành phố
        public string Country { get; set; } = string.Empty; // Quốc gia
    }

    public class BoundingBox
    {
        
    }

    public class GeoCodeResponseDto
    {
        public required string Place_id { get; set; }
        public required string Licence { get; set; }
        public required string Osm_type { get; set; }
        public required string Osm_id { get; set; }
        public required List<double> Boundingbox { get; set; }
        public required double Lat { get; set; }
        public required double Lon { get; set; }
        public required string Display_name { get; set; }
        public required string Class { get; set; }
        public required string Type { get; set; }
        public required double Importance { get; set; }
    }

    public class GeoCodeResultDto
    {
        public required List<double> Boundingbox { get; set; }
        public required double Lat { get; set; }
        public required double Lon { get; set; }
        public required string Display_name { get; set; }
        public required double Importance { get; set; }
    }
}
