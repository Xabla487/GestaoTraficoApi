using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TrafficManagementApi.Models;

namespace TrafficManagementApi
{
    public class TrafficManagementDbContext : DbContext
    {
        public TrafficManagementDbContext(DbContextOptions<TrafficManagementDbContext> options)
            : base(options)
        {
        }

        public DbSet<TrafficLight> TrafficLights { get; set; }
        public object Incidents { get; internal set; }

        internal void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public DbSet<Incident> Incidents { get; set; }

        public DbSet<TrafficFlow> TrafficFlows { get; set; }

        public DbSet<EmergencyEndpoint> EmergencyEndpoints { get; set; }
    }

}
