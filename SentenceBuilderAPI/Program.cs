using SentenceBuilderAPI.Data;
using Microsoft.EntityFrameworkCore;
using SentenceBuilderAPI.Actions.Interfaces;
using SentenceBuilderAPI.Actions.ActionClasses;
using SentenceBuilderAPI.MappingConfig;

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
