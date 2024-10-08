﻿using System;
using System.Collections.Generic;

namespace WebAPI_1721030646.Models.CMS;

public partial class AccountType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Code { get; set; } = null!;

    public int? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? UpdatedBy { get; set; }

    public string? Notes { get; set; }

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();
}
