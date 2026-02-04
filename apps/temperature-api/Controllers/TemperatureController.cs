using Microsoft.AspNetCore.Mvc;
using temperature_api.Models;

namespace temperature_api.Controllers
{
    [Route("temperature")]
    [ApiController]
    public class TemperatureController : ControllerBase
    {
        //[HttpGet("{id}")]
        //public IActionResult GetTemperature(int id)
        //{
        //    // If no location is provided, use a default based on sensor ID
        //    var location = id switch
        //    {
        //        1 => "Living Room",
        //        2 => "Bedroom",
        //        3 => "Kitchen",
        //        _ => "Unknown"
        //    };

        //    var random = new Random().Next(0, 50);

        //    var result = new TemperatureDto
        //    {
        //        Location = location,
        //        SensorID = id.ToString(),
        //        Value = random
        //    };

        //    return Ok(result);
        //}

        //[HttpGet]
        //public IActionResult GetTemperature(string? location)
        //{
        //    if (string.IsNullOrEmpty(location))
        //    {
        //        return BadRequest();
        //    }

        //    // If no sensor ID is provided, generate one based on location
        //    var sensorId = location switch
        //    {
        //        "Living Room" => "1",
        //        "Bedroom" => "2",
        //        "Kitchen" => "3",
        //        _ => "0"
        //    };

        //    var random = new Random().Next(0, 50);

        //    var result = new TemperatureDto
        //    {
        //        Location = location,
        //        SensorID = sensorId,
        //        Value = random
        //    };

        //    return Ok(result);
        //}
    }
}
