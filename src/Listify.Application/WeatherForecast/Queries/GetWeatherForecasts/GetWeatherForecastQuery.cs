using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listify.Application.WeatherForecast.Queries.GetWeatherForecasts
{
    public class GetWeatherForecastQuery : IRequest<IEnumerable<WeatherForecast>>
    {
    }
}
