using TrafficManagementApi.Models;

namespace TrafficManagementApi.Services
{
    public interface IIncidentNotificationService
    {
        void NotifyIncident(Incident incident);
    }
}
