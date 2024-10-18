using System.Collections.Generic;

namespace TrafficManagementApi.Services
{
    public interface IRouteOptimizationService
    {
        List<string> CalculateOptimalRoute(string origin, string destination);
    }
}
