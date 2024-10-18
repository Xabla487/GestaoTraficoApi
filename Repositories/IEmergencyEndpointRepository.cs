using TrafficManagementApi.Models;
using System.Collections.Generic;

namespace TrafficManagementApi.Repositories
{
    public interface IEmergencyEndpointRepository
    {
        List<EmergencyEndpoint> GetAllEmergencyEndpoints();
    }
}
