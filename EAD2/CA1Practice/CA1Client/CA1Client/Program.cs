
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Weather.Models;
using System.Web.Script.Serialization;

namespace CA1Client
{
    class Program
    {

        public static void Main()
        {
            Run().Wait();

            Console.ReadKey();
        }


        static async Task Run()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:53937/");
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.GetAsync("api/weather");               // accessing the Result property blocks
                    if (response.IsSuccessStatusCode)                                                  // 200.299
                    {
                        // read result 
                        var weather = await response.Content.ReadAsAsync<IEnumerable<WeatherInformation>>();
                        foreach (var w in weather)
                        {
                            Console.WriteLine(w.City + " " + w.Temperature + "C " + w.WindSpeed + "km/h " + w.Conditions + " warning: " + w.WeatherWarning);
                        }
                    }
                    else
                    {
                        Console.WriteLine(response.StatusCode + " " + response.ReasonPhrase);
                    }

                    // 2
                    // get weather info for Dublin
                    // GET ../api/weather/Dublin
                    WeatherInformation weatherInfo = new WeatherInformation();
                    response = await client.GetAsync("api/weather/Dublin");
                    if (response.IsSuccessStatusCode)
                    {
                        // read result 
                        weatherInfo = await response.Content.ReadAsAsync<WeatherInformation>();
                        Console.WriteLine(weatherInfo.City + " " + weatherInfo.Temperature + "C " + weatherInfo.WindSpeed + "km/h " + weatherInfo.Conditions + " Warning: " + weatherInfo.WeatherWarning);
                    }
                    else
                    {
                        Console.WriteLine(response.StatusCode + " " + response.ReasonPhrase);
                    }

                    // 3
                    // update by Put to api/weather/Dublin - now its sunny
                    weatherInfo.Conditions = weatherInfo.Conditions + "Poop";
                    response = await client.PutAsJsonAsync("api/weather/Dublin", weatherInfo);
                    if (!response.IsSuccessStatusCode)
                    {
                        Console.WriteLine(response.StatusCode + " " + response.ReasonPhrase);
                    }

                    response = await client.GetAsync("api/weather");               // accessing the Result property blocks
                    if (response.IsSuccessStatusCode)                                                  // 200.299
                    {
                        // read result 
                        var weather = await response.Content.ReadAsAsync<IEnumerable<WeatherInformation>>();
                        foreach (var w in weather)
                        {
                            Console.WriteLine(w.City + " " + w.Temperature + "C " + w.WindSpeed + "km/h " + w.Conditions + " warning: " + w.WeatherWarning);
                        }
                    }
                    else
                    {
                        Console.WriteLine(response.StatusCode + " " + response.ReasonPhrase);
                    }

                    response = await client.GetAsync("api/weather?warning=true");
                    if (response.IsSuccessStatusCode)
                    {
                        // read result 
                        var cities = await response.Content.ReadAsAsync<IEnumerable<String>>();
                        foreach (String city in cities)
                        {
                            Console.WriteLine(city);
                        }
                    }
                    else
                    {
                        Console.WriteLine(response.StatusCode + " " + response.ReasonPhrase);
                    }


                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}

