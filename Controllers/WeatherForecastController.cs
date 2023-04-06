using AppTwelve.Models;
using AppTwelve.Repository;
using Microsoft.AspNetCore.Mvc;

namespace AppTwelve.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private ISharesRepo sRepo;
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,ISharesRepo sharesRepo)
        {
            _logger = logger;
            sRepo = sharesRepo;
        }


        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [Route("share")]
        [HttpPost]
        public IActionResult addShareData(Shares shares)
        {

            sRepo.createShares(shares);
            return Ok(shares);
        }

        [Route("share")]
        [HttpGet]
        public async Task<IActionResult> getShareData()
        {

            return Ok(sRepo.allShares());
        }

        [Route("shares")]
        [HttpGet]
        public async Task<IActionResult> getSharesData(String country) {
            
            /*Call an external api with new HttpClient()*/
            var client = new HttpClient();
            var response = await client.GetAsync("https://api.twelvedata.com/stocks?country="+country);
            string responseString = await response.Content.ReadAsStringAsync();
            var shares = System.Text.Json.JsonSerializer.Deserialize<Data>(responseString);
           /* foreach (Shares s in shares.data) {
                sRepo.createShares(s);
                break;
            }*/
            return Ok(shares.data);
        }

        [Route("timeseriesshares")]
        [HttpGet]
        public async Task<IActionResult> getTimeSeriesSharesData(String symbol)
        {
           /*Call an external api with new HtppClient()*/


            var client = new HttpClient();
            var response = await client.GetAsync("https://api.twelvedata.com/time_series?symbol="+symbol+"&interval=1min&apikey=7510425dfb0b4bbf9440290467ce2a7f");
            var responseString = await response.Content.ReadAsStringAsync();
            
            return Ok(responseString);

        }
    }
}