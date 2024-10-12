using DNSParser.CoreDataEntities;
using DNSParser.CoreService;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ComputerAggregator.Kulebyakin.DNSParser.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private IItemService _itemService;      

        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        public WeatherForecastController(IItemService itemService)
        {
            _itemService = itemService;
        }

        private readonly ILogger<WeatherForecastController> _logger;

        [HttpGet("GetAll")]
        public IEnumerable<BaseItem> GetAll()
        {
            var result = _itemService.GetItems();

            return result;
        }

        [HttpGet()]
        public string GetTargetItem()
        {
            var result = _itemService.GetItem("Графический планшет XP-Pen Deco Pro M");

            return JsonConvert.SerializeObject(result);            
        }
    }
}