using Microsoft.AspNetCore.Mvc;
using TrafficManagementApi.DTOs;
using TrafficManagementApi.Services;

namespace TrafficManagementApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IncidentsController : ControllerBase
    {
        private readonly IIncidentService _incidentService;

        public IncidentsController(IIncidentService incidentService)
        {
            _incidentService = incidentService;
        }

        [HttpGet]
        public IActionResult GetIncidents(int page = 1, int pageSize = 10, string? location = null, DateTime? startDate = null, DateTime? endDate = null, string? severity = null)
        {
            var incidents = _incidentService.GetIncidents(page, pageSize, location, startDate, endDate, severity);
            return Ok(incidents);
        }

        [HttpGet("{id}")]
        public IActionResult GetIncidentById(int id)
        {
            var incident = _incidentService.GetIncidentById(id);
            if (incident == null)
            {
                return NotFound();
            }
            return Ok(incident);
        }

        [HttpPost]
        public IActionResult CreateIncident([FromBody] IncidentDto incidentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdIncident = _incidentService.CreateIncident(incidentDto);
            return CreatedAtAction(nameof(GetIncidentById), new { id = createdIncident.Id }, createdIncident);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateIncident(int id, [FromBody] IncidentDto incidentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedIncident = _incidentService.UpdateIncident(id, incidentDto);
            if (updatedIncident == null)
            {
                return NotFound();
            }
            return Ok(updatedIncident);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteIncident(int id)
        {
            var result = _incidentService.DeleteIncident(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }

}
