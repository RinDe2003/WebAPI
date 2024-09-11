using Microsoft.EntityFrameworkCore;
using WebAPI_1721030646.AutoMapperProfile;
using WebAPI_1721030646.Controllers;
using WebAPI_1721030646.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(AutoMapperEFC).Assembly);
builder.Services.AddDbContext<EfcoreDemoContext>(options =>
    options.UseSqlServer());
builder.Services.AddDbContext<EcommerceAddressContext>(options =>
    options.UseSqlServer());
builder.Services.AddDbContext<CMSContext>(options =>
    options.UseSqlServer());

//// Register your DbContext 
var getConnectionStr = builder.Configuration.GetConnectionString("MyConnectString");
builder.Services.AddDbContext<EfcoreDemoContext>(option => option.UseSqlServer(getConnectionStr));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
