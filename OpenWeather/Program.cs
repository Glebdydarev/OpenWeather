using System;
using System.IO;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace OpenWeather
{
    class Program
    {
        private static object apiKey;

        static void Main(string[] args)
        {
            var key = File.ReadAllText("appsettings.json");
            var apiKey = JObject.Parse(key).GetValue("default").ToString();

            Console.WriteLine("Plese enter your zip code: ");
            var zip_code = Console.ReadLine();
            var weatherURL = $"https://api.openweathermap.org/data/2.5/weather?zip={zip_code}&units=imperial&appid={apiKey}";
            
            var client = new HttpClient();

            var response = client.GetStringAsync(weatherURL).Result;

            var temp = double.Parse(JObject.Parse(response)["main"]["temp"].ToString());

            Console.WriteLine($"The current temperature is {temp}");



            
        }
    }
}
