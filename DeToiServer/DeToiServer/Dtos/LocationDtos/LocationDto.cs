using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace DeToiServer.Dtos.LocationDtos
{
    public class Coordinate
    {
        [JsonPropertyName("lat")] public double Latitude { get; set; }
        [JsonPropertyName("lng")] public double Longitude { get; set; }
    }

    public class ViewPortResult
    {
        [JsonPropertyName("northeast")] public required Coordinate NorthEast { get; set; }
        [JsonPropertyName("southwest")] public required Coordinate SouthWest { get; set; }
    }

    public class GeometryResult
    {
        [JsonPropertyName("location")] public required Coordinate Location { get; set; }
        [JsonPropertyName("location_type")] public string LocationType { get; set; } = string.Empty;
        [JsonPropertyName("viewport")] public required ViewPortResult ViewPort { get; set; }
    }

    public class PlusCodeResult
    {
        [JsonPropertyName("compound_code")] public string CompoundCode { get; set; } = string.Empty;
        [JsonPropertyName("global_code")] public string GlobalCode { get; set; } = string.Empty;
    }

    public class AddressComponentResult
    {
        [JsonPropertyName("long_name")] public string LongName { get; set; } = string.Empty;
        [JsonPropertyName("short_name")] public string ShortName { get; set; } = string.Empty;
        [JsonPropertyName("types")] public required IEnumerable<string> Types { get; set; }
    }

    public class GeoCodeResultDto
    {
        [JsonPropertyName("address_components")] public required IEnumerable<AddressComponentResult> AddressComponents { get; set; }
        [JsonPropertyName("formatted_address")] public string FormattedAddress { get; set; } = string.Empty;
        [JsonPropertyName("geometry")] public required GeometryResult Geometry { get; set; }
        [JsonPropertyName("place_id")] public string PlaceId { get; set; } = string.Empty;
        [JsonPropertyName("plus_code")] public required PlusCodeResult PlusCode { get; set; }
        [JsonPropertyName("types")] public required IEnumerable<string> Types { get; set; }
    }

    public class GeoCodeResponseDto
    {
        [JsonPropertyName("results")] public required IEnumerable<GeoCodeResultDto> Results { get; set; }
        [JsonPropertyName("status")] public string Status { get; set; } = string.Empty;
    }

}
