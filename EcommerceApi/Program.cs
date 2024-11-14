using EcommerceApi.Data;
using EcommerceShared.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Register DbContext with SQL Server or SQLite
builder.Services.AddDbContext<EcommerceDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services and controllers
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
/* builder.Services.AddHttpClient<CategoryService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5000");
}); */

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/api/categories", async (EcommerceDbContext context) =>
{
    var categories = await context.Categories.ToListAsync();
    return categories;
})
.WithName("GetCategories")
.WithOpenApi();

// Map controllers
app.MapControllers();

app.MapGet("/api/products", async (EcommerceDbContext context) =>
{
    var products = await context.Products.ToListAsync();
    return products;
})
.WithName("GetProducts")
.WithOpenApi();

app.Run();
