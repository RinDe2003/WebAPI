using System;
using System.Collections.Generic;

namespace WebAPI_1721030646.DTO.DDE;

public partial class ProvinceDTO
{
    public int ProvinceId { get; set; }

    public string ProvinceName { get; set; } = null!;

    public string ProvinceCode { get; set; } = null!;

    public string AxisMeridian { get; set; } = null!;

    public int CountryId { get; set; }

    public bool Status { get; set; }

    public string CreatedAt { get; set; } = null!;

    public string CreatedBy { get; set; } = null!;

    public string UpdatedAt { get; set; } = null!;

    public string UpdatedBy { get; set; } = null!;
}
