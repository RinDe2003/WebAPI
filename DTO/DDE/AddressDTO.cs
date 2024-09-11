using System;
using System.Collections.Generic;

namespace WebAPI_1721030646.DTO.DDE;

public partial class AddressDTO
{
    public int AddressId { get; set; }

    public int CountryId { get; set; }

    public int ProvinceId { get; set; }

    public int DistrictId { get; set; }

    public int WardId { get; set; }

    public int TownId { get; set; }

    public bool Status { get; set; }

    public string Latitude { get; set; } = null!;

    public string Longitude { get; set; } = null!;

    public string? Notes { get; set; }
}
