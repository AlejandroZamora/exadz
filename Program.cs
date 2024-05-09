using Microsoft.OpenApi.Models;
using product.DB;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
     c.SwaggerDoc("v1", new OpenApiInfo { Title = "Examen2 API", Description = "Handle the Products you love", Version = "v1" });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
   app.UseSwagger();
   app.UseSwaggerUI(c =>
   {
      c.SwaggerEndpoint("/swagger/v1/swagger.json", "Examen2 API V1");
   });
}
/*
app.MapGet("/", () => "Hello World!");*/

app.MapGet("/Producto/{id}", (int id) => ProductoDB.GetProducto(id));
app.MapGet("/Producto", () => ProductoDB.GetProducto());
app.MapPost("/Producto", (Producto producto) => ProductoDB.CreateProducto(producto));
app.MapPut("/Producto", (Producto producto) => ProductoDB.UpdateProducto(producto));
app.MapDelete("/Producto/{id}", (int id) => ProductoDB.RemoveProducto(id));

app.Run();
