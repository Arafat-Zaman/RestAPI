using RestAPI;
using System;
using System.Threading.Tasks;

namespace RestAPI
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.Write("Enter city name: ");
            string city = Console.ReadLine();

            WeatherService weatherService = new WeatherService();
            WeatherData weatherData = await weatherService.GetWeatherAsync(city);

            if (weatherData != null)
            {
                Console.WriteLine($"Temperature in {weatherData.City}: {weatherData.Temperature.Temperature}°C");
            }

            Console.ReadKey();
        }
    }
}
