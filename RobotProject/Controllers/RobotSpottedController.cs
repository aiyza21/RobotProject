using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RobotProject.services;
using System.Text.Json;

namespace RobotProject.Controllers;

[ApiController]
[Route("[controller]")]
public class RobotSpottedController : ControllerBase
{
    private readonly ILogger<RobotSpottedController> _logger;
    private readonly LocationService _service;

    public RobotSpottedController(LocationService service, ILogger<RobotSpottedController> logger)
    {
        _service = service;
        _logger = logger;
    }

    [HttpPost(Name = "RobotSpotted")]
    public async Task<string> Post(Location location)
    { 
        _logger.Log(LogLevel.Information, new EventId(), null, "Logged:" + location.LocationName, null);


        string WaterSourceResponse = await _service.GetNearestRiverFromLocation(location);


        System.Text.Json.JsonSerializer.Serialize(WaterSourceResponse);

        // DESERILISING
        WaterSourceLocation[] WaterSource = System.Text.Json.JsonSerializer.Deserialize<WaterSourceLocation[]>(WaterSourceResponse);
        return $"Send robot to: {location.LocationName} is {WaterSource[0].display_name}";

    }
}

