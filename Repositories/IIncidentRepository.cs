using TrafficManagementApi.Models;
using System.Collections.Generic;

namespace TrafficManagementApi.Repositories
{
    public interface IIncidentRepository
    {
        List<Incident> GetIncidents(int page, int pageSize, string? location = null, DateTime? startDate = null, DateTime? endDate = null, string? severity = null);
        int GetTotalCount(string? location = null, DateTime? startDate = null, DateTime? endDate = null, string? severity = null);
        Incident GetIncidentById(int id);
        void AddIncident(Incident incident);
        void SaveChanges();
        object DeleteIncident(Incident incident);
        void UpdateIncident(Incident incident);
        void DeleteIncident(Incident incident);
        // Outros métodos para atualizar e excluir incidentes (opcional)
    }
}
