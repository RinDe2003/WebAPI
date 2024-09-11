﻿using System;
using System.Collections.Generic;

namespace WebAPI_1721030646.DTO.CMS;

public partial class AddressDTO
{
    public int Id { get; set; }

    public string? AddressText { get; set; }

    public int? CountryId { get; set; }

    public int? ProvinceId { get; set; }

    public int? DistrictId { get; set; }

    public int? WardId { get; set; }

    public int? TownId { get; set; }

    public int? Status { get; set; }

    public double? Latitude { get; set; }

    public double? Longitude { get; set; }

    public string? Notes { get; set; }
}
