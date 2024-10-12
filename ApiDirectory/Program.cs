using Service.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddServices(builder.Configuration);

var app = builder.Build();
app.MigrateDatabase();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
