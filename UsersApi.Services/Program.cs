using UsersApi.Infra.IoC.Extensions;
using UsersApi.Services.Extensions;
using UsersApi.Services.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddRouting(map => map.LowercaseUrls = true);
builder.Services.AddSwaggerConfig();
builder.Services.AddDbContextConfig(builder.Configuration);
builder.Services.AddJwtBearerConfig(builder.Configuration);
builder.Services.AddServicesConfig();
builder.Services.AddCultureInfo();

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();
app.UseSwaggerConfig();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();

public partial class Program { }
