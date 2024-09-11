using System;
using System.Collections.Generic;

namespace WebAPI_1721030646.Models.DDE;

public partial class District
{
    public int DistrictId { get; set; }

    public string DistrictName { get; set; } = null!;

    public string DistrictCode { get; set; } = null!;

    public int ProvinceId { get; set; }

    public bool Status { get; set; }

    public string CreatedAt { get; set; } = null!;

    public string CreatedBy { get; set; } = null!;

    public string UpdatedAt { get; set; } = null!;

    public string UpdatedBy { get; set; } = null!;

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();
}
