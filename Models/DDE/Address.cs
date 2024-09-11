﻿using System;
using System.Collections.Generic;

namespace WebAPI_1721030646.Models.DDE;

public partial class Address
{
    public int AddressId { get; set; }

    public string AddressText { get; set; } = null!;

    public int CountryId { get; set; }

    public int ProvinceId { get; set; }

    public int DistrictId { get; set; }

    public int WardId { get; set; }

    public int TownId { get; set; }

    public bool Status { get; set; }

    public string Latitude { get; set; } = null!;

    public string Longitude { get; set; } = null!;

    public string? Notes { get; set; }

    public virtual Country Country { get; set; } = null!;

    public virtual District District { get; set; } = null!;

    public virtual Province Province { get; set; } = null!;

    public virtual Ward Ward { get; set; } = null!;
}
