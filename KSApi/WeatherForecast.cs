using System;

namespace KSApi
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
    }

    public interface IUser
    {
        string FullName();
    }

    public class User : IUser
    {
        public string FullName()
        {
            return "Filankes Filankesov";
        }
    }
}
