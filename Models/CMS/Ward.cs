using System;
using System.Collections.Generic;

namespace WebAPI_1721030646.Models.CMS;

public partial class Ward
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string WardCode { get; set; } = null!;

    public int DistrictId { get; set; }

    public int? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? UpdatedBy { get; set; }

    public virtual District District { get; set; } = null!;
}
