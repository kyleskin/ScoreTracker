using ScoreTracker.WebApi.Helpers;
using ScoreTracker.WebApi.Interfaces;
using ScoreTracker.WebApi.MLBTracker.Models;
using ScoreTracker.WebApi.MLBTracker.Services;
using ScoreTracker.WebApi.NBAScoreTracker.Models;
using ScoreTracker.WebApi.NBAScoreTracker.Services;
using ScoreTracker.WebApi.NCAAFootball.Models;
using ScoreTracker.WebApi.NCAAFootball.Services;
using ScoreTracker.WebApi.NHLScoreTracker.Models;
using ScoreTracker.WebApi.NHLScoreTracker.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IScoreboardService<MLBScoreboard>, MLBScoreboardService>();
builder.Services.AddScoped<IScoreboardService<NBAScoreboard>, NBAScoreboardService>();
builder.Services.AddScoped<IScoreboardService<NHLScoreboard>, NHLScoreboardService>();
builder.Services.AddScoped<IScoreboardService<NCAAFootballScoreboard>, NCAAFootballScoreboardService>();

builder.Services.AddHttpClients();

// builder.Services.AddHttpClient<IScoreboardService<MLBScoreboard>, MLBScoreboardService>((client =>
// {
//     client.BaseAddress = new Uri("http://site.api.espn.com");
// }));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// const string espnBaseSite = "http://site.api.espn.com";
//
// builder.Services.AddHttpClient<IScoreboardService<MLBScoreboardService>>((client) =>
// {
//     client.BaseAddress = new Uri("http://site.api.espn.com");
// });
//
// builder.Services.AddHttpClient<NBAScoreboardService>((client) =>
// {
//     client.BaseAddress = new Uri(espnBaseSite);
// });
//
// builder.Services.AddHttpClient<NCAAFootballScoreboardService>((client) =>
// {
//     client.BaseAddress = new Uri(espnBaseSite);
// });
//
// builder.Services.AddHttpClient<NHLScoreboardService>((client) =>
// {
//     client.BaseAddress = new Uri(espnBaseSite);
// });



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    // app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();