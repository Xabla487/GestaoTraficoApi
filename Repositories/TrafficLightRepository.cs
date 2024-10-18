using TrafficManagementApi.Models;
using Microsoft.EntityFrameworkCore;

namespace TrafficManagementApi.Repositories
{
    public class TrafficLightRepository : ITrafficLightRepository
    {
        private readonly TrafficManagementDbContext _context;

        public TrafficLightRepository(TrafficManagementDbContext context)
        {
            _context = context;
        }

        public List<TrafficLight> GetTrafficLights(int page, int pageSize)
        {
            return _context.TrafficLights
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public int GetTotalCount()
        {
            return _context.TrafficLights.Count();
        }

        public TrafficLight GetTrafficLightById(int id)
        {
            return _context.TrafficLights.Find(id);
        }

        public List<TrafficFlow> GetTrafficFlowData(string? location, DateTime? startDate, DateTime? endDate)
        {
            var query = _context.TrafficFlows.AsQueryable();

            if (!string.IsNullOrEmpty(location))
            {
                query = query.Where(tf => tf.Location.Contains(location));
            }

            if (startDate.HasValue)
            {
                query = query.Where(tf => tf.Timestamp >= startDate.Value);
            }

            if (endDate.HasValue)
            {
                query = query.Where(tf => tf.Timestamp <= endDate.Value);
            }

            return query.ToList();
        }

        public List<TrafficLight> GetAllTrafficLights()
        {
            return _context.TrafficLights.ToList();
        }
    }
}
