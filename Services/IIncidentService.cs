using TrafficManagementApi.DTOs;
using TrafficManagementApi.ViewModels;

namespace TrafficManagementApi.Services
{
    public interface IIncidentService
    {
        IncidentsViewModel GetIncidents(int page, int pageSize, string? location = null, DateTime? startDate = null, DateTime? endDate = null, string? severity = null);
        IncidentDto GetIncidentById(int id);
        IncidentDto CreateIncident(IncidentDto incidentDto);
        object UpdateIncident(int id, IncidentDto incidentDto);
        bool DeleteIncident(int id);
        // Outros métodos para atualizar e excluir incidentes (opcional)
    }
}
