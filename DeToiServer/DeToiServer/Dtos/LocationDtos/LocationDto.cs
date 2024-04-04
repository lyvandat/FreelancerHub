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

    public class GeoCodeErrorDto
    {
        public string Code { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
    }

    public class GeoCodeErrorResponseDto
    {
        public GeoCodeErrorDto? Error { get; set; }
    }


    public class LocationDto
    {
        public double Lat { get; set; }
        public double Lng { get; set; }
    }

    public class GeometryDto
    {
        public required LocationDto Location { get; set; }
    }

    public class PlusCodeDto
    {
        public string Compound_code { get; set; } = string.Empty;
        public string Global_code { get; set; } = string.Empty;
    }

    public class AddressComponentDto
    {
        public string Long_name { get; set; } = string.Empty;
        public string Short_name { get; set; } = string.Empty;
    }

    public class LocationAddressResultDto
    {
        public required IEnumerable<AddressComponentDto> Address_components { get; set; }
        public string Formatted_address { get; set; } = string.Empty;
        public required GeometryDto Geometry { get; set; }
        public string Place_id { get; set; } = string.Empty;
        public string Reference { get; set; } = string.Empty;
        public required PlusCodeDto Plus_code { get; set; }
        public IEnumerable<string>? Types { get; set; }
    }

    public class GeoCodeResponseDto
    {
        public PlusCodeDto? Plus_code { get; set; }
        public required IEnumerable<LocationAddressResultDto> Results { get; set; }
        public string Status { get; set; } = string.Empty;
    }

    public class RevGeoCodeResultDto
    {
        public double Lat { get; set; }
        public double Lon { get; set; }
        public string Display_name { get; set; } = string.Empty;
        public string PlaceId { get; set; } = string.Empty;

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

    public class GeoCodeResultDto
    {
        public required List<double> Boundingbox { get; set; }
        public required double Lat { get; set; }
        public required double Lon { get; set; }
        public required string Display_name { get; set; }
        public string? Amenity { get; set; }
        public string? House_number { get; set; }
        public string? Road { get; set; }

        public string Ward { get; set; } = string.Empty; // Phường - Xã, thị trấn
        public string District { get; set; } = string.Empty; // Quận - Huyện
        public string Province { get; set; } = string.Empty; // tỉnh - thành phố
        public string Country { get; set; } = string.Empty; // Quốc gia
        public required double Importance { get; set; }
    }
}
