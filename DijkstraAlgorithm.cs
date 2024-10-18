using System;
using System.Collections.Generic;
using System.Linq;

namespace TrafficManagementApi.Algorithms
{
    public class DijkstraAlgorithm
    {
        private readonly Dictionary<string, Dictionary<string, int>> _graph;

        public DijkstraAlgorithm(Dictionary<string, Dictionary<string, int>> graph)
        {
            _graph = graph;
        }

        public List<string> FindShortestPath(string start, string end)
        {
            var distances = new Dictionary<string, int>();
            var previous = new Dictionary<string, string>();
            var queue = new List<string>();

            foreach (var vertex in _graph.Keys)
            {
                distances[vertex] = int.MaxValue;
                previous[vertex] = null;
                queue.Add(vertex);
            }

            distances[start] = 0;

            while (queue.Count > 0)
            {
                var current = queue.OrderBy(v => distances[v]).First();
                queue.Remove(current);

                if (current == end)
                {
                    break;
                }

                foreach (var neighbor in _graph[current].Keys)
                {
                    var alt = distances[current] + _graph[current][neighbor];
                    if (alt < distances[neighbor])
                    {
                        distances[neighbor] = alt;
                        previous[neighbor] = current;
                    }
                }
            }

            var path = new List<string>();
            var currentVertex = end;
            while (currentVertex != null)
            {
                path.Add(currentVertex);
                currentVertex = previous[currentVertex];
            }
            path.Reverse();
            return path;
        }
    }
}
