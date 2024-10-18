using System.Collections.Generic;
using TrafficManagementApi.Models;
using TrafficManagementApi.Repositories;
using TrafficManagementApi.Services.TrafficManagementApi.Services;

namespace TrafficManagementApi.Services
{
    public class RouteOptimizationService : IRouteOptimizationService
    {
        private readonly ITrafficLightRepository _trafficLightRepository;

        public RouteOptimizationService(ITrafficLightRepository trafficLightRepository)
        {
            _trafficLightRepository = trafficLightRepository;
        }

        public List<string> CalculateOptimalRoute(string origin, string destination)
        {
            var graph = BuildTrafficGraph(); // Construir o grafo com base nos dados de tráfego

            var dijkstra = new DijkstraAlgorithm(graph);
            var path = dijkstra.FindShortestPath(origin, destination);

            return path;
        }

        private Dictionary<string, Dictionary<string, int>> BuildTrafficGraph()
        {

            return new Dictionary<string, Dictionary<string, int>>
            {
                { "A", new Dictionary<string, int> { { "B", 10 }, { "C", 15 } } },
                { "B", new Dictionary<string, int> { { "D", 12 }, { "E", 15 } } },
                { "C", new Dictionary<string, int> { { "F", 10 } } },
                { "D", new Dictionary<string, int> { { "F", 2 } } },
                { "E", new Dictionary<string, int> { { "F", 5 } } },
                { "F", new Dictionary<string, int>() }
            };
        }

        private Dictionary<string, Dictionary<string, int>> BuildTrafficGraph()
        {
            var trafficLights = _trafficLightRepository.GetAllTrafficLights();
            var graph = new Dictionary<string, Dictionary<string, int>>();

            foreach (var trafficLight in trafficLights)
            {
                graph[trafficLight.Location] = new Dictionary<string, int>();
            }

            return graph;
        }
    }
}
