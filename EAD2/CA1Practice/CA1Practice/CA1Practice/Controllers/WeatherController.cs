using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CA1Practice.Controllers
{

    public class WeatherController : ApiController
    {
        public static List<Models.Weather> weather = new List<Models.Weather>
        {
            new Models.Weather { city = "Dublin", temperature = 4, conditions = "Cloudy", weatherWarning = false, windSpeed = 20 },
            new Models.Weather { city = "Paris", temperature = 20, conditions = "Temperate", weatherWarning = false, windSpeed = 10 },
            new Models.Weather { city = "Berlin", temperature = -3, conditions = "Windy", weatherWarning = true, windSpeed = 50 },
            new Models.Weather { city = "Amsterdam", temperature = 14, conditions = "Grand", weatherWarning = false, windSpeed = 25 }
        };


        // GET: api/Weather
        public IEnumerable<Models.Weather> Get()
        {
            return weather;
        }


        [Route("api/weather/{city}")]
        public Models.Weather getCity(String city)
        {
            Models.Weather cities = weather.FirstOrDefault(w => w.city.ToUpper().Equals(city.ToUpper()));
            if (cities == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return cities;

        }

        public IEnumerable<String> getWarning(bool warning)
        {
            var city = weather.Where(w => w.weatherWarning == warning).Select(w => w.city);
            return city;
        }
        
        [HttpPut]
        [Route("api/weather/{city}")]
        public void PutUpdateCity(String city, Models.Weather toUpdate)
        {
            if (ModelState.IsValid)
            {
                if (city == toUpdate.city)
                {
                    int index = weather.FindIndex(w => w.city.ToUpper() == toUpdate.city.ToUpper());
                    if (index == -1)
                        throw new HttpResponseException(HttpStatusCode.NotFound);
                    else
                    {
                        weather.RemoveAt(index);
                        weather.Add(toUpdate);
                    }

                }
                else
                    throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            else
                throw new HttpResponseException(HttpStatusCode.NotImplemented);


        }

        // PUT: api/Weather/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Weather/5
        public void Delete(int id)
        {
        }
    }
}
