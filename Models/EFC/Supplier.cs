using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;

namespace WebAPI_1721030646.Models.EFC;

public partial class Supplier
{
    public int SupplierId { get; set; }

    public string CompanyName { get; set; } = null!;

    public string? Phone { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}


public static class SupplierEndpoints
{
    public static void MapSupplierEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Supplier").WithTags(nameof(Supplier));

        group.MapGet("/", () =>
        {
            return new[] { new Supplier() };
        })
        .WithName("GetAllSuppliers")
        .WithOpenApi();

        group.MapGet("/{id}", (int id) =>
        {
            //return new Supplier { ID = id };
        })
        .WithName("GetSupplierById")
        .WithOpenApi();

        group.MapPut("/{id}", (int id, Supplier input) =>
        {
            return TypedResults.NoContent();
        })
        .WithName("UpdateSupplier")
        .WithOpenApi();

        group.MapPost("/", (Supplier model) =>
        {
            //return TypedResults.Created($"/api/Suppliers/{model.ID}", model);
        })
        .WithName("CreateSupplier")
        .WithOpenApi();

        group.MapDelete("/{id}", (int id) =>
        {
            //return TypedResults.Ok(new Supplier { ID = id });
        })
        .WithName("DeleteSupplier")
        .WithOpenApi();
    }
}