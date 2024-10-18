using TrafficManagementApi.Models;
using Microsoft.EntityFrameworkCore;

namespace TrafficManagementApi.Repositories
{
    public class IncidentRepository : IIncidentRepository
    {
        private readonly TrafficManagementDbContext _context;

        public IncidentRepository(TrafficManagementDbContext context)
        {
            _context = context;
        }

        public List<Incident> GetIncidents(int page, int pageSize, string? location = null, DateTime? startDate = null, DateTime? endDate = null, string? severity = null)
        {
            var query = _context.Incidents.AsQueryable();

            if (!string.IsNullOrEmpty(location))
            {
                query = query.Where(i => i.Location.Contains(location));
            }

            if (startDate.HasValue)
            {
                query = query.Where(i => i.Timestamp >= startDate.Value);
            }

            if (endDate.HasValue)
            {
                query = query.Where(i => i.Timestamp <= endDate.Value);
            }

            if (!string.IsNullOrEmpty(severity))
            {
                query = query.Where(i => i.Severity == severity);
            }

            return query.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }

        public int GetTotalCount(string? location = null, DateTime? startDate = null, DateTime? endDate = null, string? severity = null)
        {
            var query = _context.Incidents.AsQueryable();

            if (!string.IsNullOrEmpty(location))
            {
                query = query.Where(i => i.Location.Contains(location));
            }

            if (startDate.HasValue)
            {
                query = query.Where(i => i.Timestamp >= startDate.Value);
            }

            if (endDate.HasValue)
            {
                query = query.Where(i => i.Timestamp <= endDate.Value);
            }

            if (!string.IsNullOrEmpty(severity))
            {
                query = query.Where(i => i.Severity == severity);
            }

            return query.Count();
        }

        public Incident GetIncidentById(int id)
        {
            return _context.Incidents.Find(id);
        }

        public void AddIncident(Incident incident)
        {
            _context.Incidents.Add(incident);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void UpdateIncident(Incident incident)
        {
            _context.Entry(incident).State = EntityState.Modified;
        }

        public void DeleteIncident(Incident incident)
        {
            _context.Incidents.Remove(incident);
        }

        // Outros métodos para atualizar e excluir incidentes (opcional)
    }
}
