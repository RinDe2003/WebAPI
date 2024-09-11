using System;
using System.Collections.Generic;

namespace WebAPI_1721030646.Models.EFC;

public partial class Category
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public string? Descriptions { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
