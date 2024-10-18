using TrafficManagementApi.Models;
using Microsoft.EntityFrameworkCore;

namespace TrafficManagementApi.Repositories
{
    public class EmergencyEndpointRepository : IEmergencyEndpointRepository
    {
        private readonly TrafficManagementDbContext _context;

        public EmergencyEndpointRepository(TrafficManagementDbContext context)
        {
            _context = context;
        }

        public List<EmergencyEndpoint> GetAllEmergencyEndpoints()
        {
            return _context.EmergencyEndpoints.ToList();
        }
    }
}
