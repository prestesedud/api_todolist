using System.Text.Json.Serialization;
using api_todolist.Api.Extensions;
using api_todolist.Application.Config;
using api_todolist.Infra.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using api_todolist.Api.Extensions;
using api_todolist.Api.Middlewares;
using api_todolist.Application.Config;
using api_todolist.Infra.Context;
using api_todolist.Infra.Interfaces;
using MoneyScope.Ioc;


var builder = WebApplication.CreateBuilder(args);
ConfigurationManager config = builder.Configuration;
builder.Services.AddSingleton(d => config);

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

builder.Services.AddDbContext<api_todolistContext>(options =>
{
    options.UseMySql(config["ConnectionStrings:Conn"],
        new MySqlServerVersion(new Version(8, 0)))
        .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddFilter((category, level) =>
            category == DbLoggerCategory.Database.Command.Name && level == LogLevel.Information)));
}, ServiceLifetime.Transient);




builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddAuthenticationConfiguration(config);
//builder.Services.AddAuthorizationConfiguration();
builder.Services.AddSwaggerConfiguration();


//configura mapeamentos de IOptions do appsettings
builder.Services.AddConfiguredOptions(builder.Configuration);

//builder.Services.Configure<EnvironmentVars>(options =>
//{
//    builder.Configuration.GetSection("Vars").Bind(options);
//});

builder.Services.AddMemoryCache();

var migrationConfig = builder.Configuration.GetSection(nameof(MigrationConfig)).Get<MigrationConfig>();

builder.Services.InjectDependencies(migrationConfig);
builder.Services.AddHttpContextAccessor();

//Cors
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());
});

var app = builder.Build();


//swagger
app.UseStaticFiles();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "api_todolist");
    c.InjectStylesheet("/swagger-ui/swagger-dark.css");
});


app.UseRouting();
app.UseCors();
app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();

#region Middlewares
//app.UseMiddleware<JwtMiddleware>();
app.UseMiddleware(typeof(HandlingMiddleware));
#endregion Middlewares

app.MapControllers();
app.Run();

