using TrafficManagementApi.DTOs;
using TrafficManagementApi.Models;
using TrafficManagementApi.Repositories;
using TrafficManagementApi.ViewModels;

namespace TrafficManagementApi.Services
{
    public class IncidentService : IIncidentService
    {
        private readonly IIncidentRepository _incidentRepository;

        public IncidentService(IIncidentRepository incidentRepository)
        {
            _incidentRepository = incidentRepository;
        }

        public IncidentsViewModel GetIncidents(int page, int pageSize, string? location = null, DateTime? startDate = null, DateTime? endDate = null, string? severity = null)
        {
            var incidents = _incidentRepository.GetIncidents(page, pageSize, location, startDate, endDate, severity);
            var totalCount = _incidentRepository.GetTotalCount(location, startDate, endDate, severity);

            return new IncidentsViewModel
            {
                Incidents = incidents.Select(i => new IncidentDto
                {
                    Id = i.Id,
                    Type = i.Type,
                    Location = i.Location,
                    Severity = i.Severity,
                    Description = i.Description,
                    Timestamp = i.Timestamp
                }).ToList(),
                TotalCount = totalCount,
                PageNumber = page,
                PageSize = pageSize
            };
        }

        public IncidentDto GetIncidentById(int id)
        {
            var incident = _incidentRepository.GetIncidentById(id);
            if (incident == null)
            {
                // Tratar o caso em que o incidente não é encontrado (lançar exceção, retornar null, etc.)
            }
            return new IncidentDto
            {
                Id = incident.Id,
                Type = incident.Type,
                Location = incident.Location,
                Severity = incident.Severity,
                Description = incident.Description,
                Timestamp = incident.Timestamp
            };
        }

        public IncidentDto CreateIncident(IncidentDto incidentDto)
        {
            var incident = new Incident
            {
                Type = incidentDto.Type,
                Location = incidentDto.Location,
                Severity = incidentDto.Severity,
                Description = incidentDto.Description,
                Timestamp = incidentDto.Timestamp
            };

            _incidentRepository.AddIncident(incident);
            _incidentRepository.SaveChanges();

            incidentDto.Id = incident.Id;
            return incidentDto;
        }

        public IncidentDto UpdateIncident(int id, IncidentDto incidentDto)
        {
            var existingIncident = _incidentRepository.GetIncidentById(id);
            if (existingIncident == null)
            {
                return null; // Ou lance uma exceção NotFoundException
            }

            existingIncident.Type = incidentDto.Type;
            existingIncident.Location = incidentDto.Location;
            existingIncident.Severity = incidentDto.Severity;
            existingIncident.Description = incidentDto.Description;
            existingIncident.Timestamp = incidentDto.Timestamp;

            _incidentRepository.SaveChanges();

            return incidentDto;
        }

        public bool DeleteIncident(int id)
        {
            var incident = _incidentRepository.GetIncidentById(id);
            if (incident == null)
            {
                return false;
            }

            object value = _incidentRepository.DeleteIncident(incident);
            _incidentRepository.SaveChanges();
            return true;
        }
    }
}
