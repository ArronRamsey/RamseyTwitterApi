using Core;
using Core.Services.Implementations;
using Core.Services.Interfaces;
using Data.Repositories.Implementations;
using Data.Repositories.Interfaces;
using Infrastructure.Services.Implementations;
using Infrastructure.Services.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using RamseyTwitterApi.HostedServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<Settings>(builder.Configuration.GetSection("Options"));
builder.Services.AddMemoryCache();
builder.Services.AddSingleton<ISettingService, SettingService>();
builder.Services.AddSingleton<IDateTimeService, DateTimeService>();
builder.Services.AddSingleton<ITwitterApiService, TweetInviService>();
builder.Services.AddSingleton<ITweetRepository, TweetRepository>();
builder.Services.AddSingleton<IThreadingService, ThreadingService>();
builder.Services.AddSingleton<ICache, MemoryCacheService>();
builder.Services.AddSingleton<ITweetService, TweetService>();
builder.Services.AddHostedService<TwitterStreamHostedService>();
builder.Services.AddHostedService<TweetLoggerHostedService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
