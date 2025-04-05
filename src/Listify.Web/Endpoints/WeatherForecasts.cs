using Listify.Web.Infrastructure;
using Microsoft.AspNetCore.Builder;

namespace Listify.Web.Endpoints
{
    public class WeatherForecasts : EndpointGroupBase
    {
        private readonly string[] summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public override void Map(WebApplication app)
        {
            app.MapGet("/api/weatherforecast", GetWeatherForecasts)
                .WithName(nameof(GetWeatherForecasts))
                .WithOpenApi();
        }

        public IEnumerable<WeatherForecast> GetWeatherForecasts()
        {
            var forecast = Enumerable.Range(1, 5).Select(index =>
            new WeatherForecast
            (
                DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                Random.Shared.Next(-20, 55),
                summaries[Random.Shared.Next(summaries.Length)]
            ))
            .ToArray();
            return forecast;
        }
    }
}
