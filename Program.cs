using WebApiDapper.DataConText;
using WebApiDapper.Models;
using WebApiDapper.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddScoped<DapperConText>();
builder.Services.AddScoped<IAllServices<Car>,CarServices>();
builder.Services.AddScoped<IAllServices<Location>,LocationService>();
builder.Services.AddScoped<IAllServices<Rental>,RetalService>();
builder.Services.AddScoped<IAllServices<Customer>,CustomerService>();
builder.Services.AddScoped<IAllServices<CarLocation>,CarLocationService>();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", "WebAPI1"));
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
