﻿using System;
using System.Collections.Generic;

namespace WebAPI_1721030646.DTO.DDE;

public partial class WardDTO
{
    public int WardId { get; set; }

    public string WardName { get; set; } = null!;

    public string WardCode { get; set; } = null!;

    public int DistrictId { get; set; }

    public bool Status { get; set; }

    public string CreatedAt { get; set; } = null!;

    public string CreatedBy { get; set; } = null!;

    public string UpdatedAt { get; set; } = null!;

    public string UpdatedBy { get; set; } = null!;
}
