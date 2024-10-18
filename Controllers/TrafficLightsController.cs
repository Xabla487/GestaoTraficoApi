// Controllers/TrafficLightsController.cs
using Microsoft.AspNetCore.Mvc;
using TrafficManagementApi.Models;

[ApiController]
[Route("api/[controller]")]
public class TrafficLightsController : ControllerBase
{
    private readonly ITrafficLightService _trafficLightService;

    public TrafficLightsController(ITrafficLightService trafficLightService)
    {
        _trafficLightService = trafficLightService;
    }

    [HttpGet]
    public IActionResult GetTrafficLights(int page = 1, int pageSize = 10)
    {
        var trafficLights = _trafficLightService.GetTrafficLights(page, pageSize);
        return Ok(trafficLights);
    }

    [HttpPut("{id}/control")]
    public IActionResult ControlTrafficLight(int id, [FromBody] TrafficLightControl trafficLightControl)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = _trafficLightService.ControlTrafficLight(id, trafficLightControl);
        if (result)
        {
            return Ok(); // Ou NoContent() se não precisar retornar nada
        }
        else
        {
            return NotFound(); // Ou BadRequest() se a ação não for válida
        }
    }
    
    [HttpGet("trafficflow")]
    public IActionResult GetTrafficFlowData(string? location = null, DateTime? startDate = null, DateTime? endDate = null)
    {
        var trafficFlowData = _trafficLightService.GetTrafficFlowData(location, startDate, endDate);
        return Ok(trafficFlowData);
    }

    [HttpGet("routes")]
    public IActionResult GetOptimalRoute(string origin, string destination)
    {
        var route = _routeOptimizationService.CalculateOptimalRoute(origin, destination);
        return Ok(route);
    }
}
