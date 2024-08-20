using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace RestAPI
{
    public class WeatherService
    {
        private readonly HttpClient _httpClient;

        string city = "Cairo"; // Example city name
        string apiKey = "42b0862fb87984defb853456bbbecedd";



        public WeatherService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<WeatherData> GetWeatherAsync(string city)
        {
           

            try
            {
                string encodedCity = HttpUtility.UrlEncode(city); // URL-encode the city name


                HttpResponseMessage response = await _httpClient.GetAsync($"http://api.openweathermap.org/data/2.5/weather?q={encodedCity}&appid={apiKey}&units=metric");


                //HttpResponseMessage response = await _httpClient.GetAsync($"http://api.openweathermap.org/data/2.5/weather?q={city}&appid=42b0862fb87984defb853456bbbecedd&units=metric");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                WeatherData weatherData = JsonConvert.DeserializeObject<WeatherData>(responseBody);
                return weatherData;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error getting weather data: {ex.Message}");
                return null;
            }
        }
    }
   
}
