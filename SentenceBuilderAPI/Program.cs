using SentenceBuilderAPI.Data;
using Microsoft.EntityFrameworkCore;
using SentenceBuilderAPI.Actions.Interfaces;
using SentenceBuilderAPI.Actions.ActionClasses;
using SentenceBuilderAPI.MappingConfig;
using Microsoft.OpenApi.Models;
using SentenceBuilderAPI.Authentication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<ISentenceActions, SentenceActions>();
builder.Services.AddTransient<IWordActions, WordActions>();
builder.Services.AddTransient<IExceptionsLogActions, LogExceptionActions>();
builder.Services.AddTransient<IWordTypeActions, WordTypeActions>();
builder.Services.AddControllers();

builder.Services.AddAutoMapper(typeof(MappingConfig));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultSQLConnection"));
});

builder.Services.AddSwaggerGen(c =>
{
    var securitySchema = new OpenApiSecurityScheme
    {
        Description = "API authorization query using the api key scheme. Example: \"Authorization: API Key {token}\"",
        Name = "api_key",
        In = ParameterLocation.Query,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "api_key",
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "Bearer"
        }
    };
    c.AddSecurityDefinition("Bearer", securitySchema);
    var securityRequirement = new OpenApiSecurityRequirement
    {
        {securitySchema, new[] {"Bearer"} }
    };
    c.AddSecurityRequirement(securityRequirement);
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<ApiKeyAuthMiddleware>();
app.UseAuthorization();

app.MapControllers();

app.Run();
