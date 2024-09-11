using System;
using System.Collections.Generic;

namespace WebAPI_1721030646.DTO.CMS;

public partial class CommentDTO
{
    public int Id { get; set; }

    public string FullName { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string Message { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Phone { get; set; }

    public int? AccountId { get; set; }

    public int? Status { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? Notes { get; set; }
}
