using TrafficManagementApi.DTOs;

namespace TrafficManagementApi.ViewModels
{
    public class IncidentsViewModel
    {
        public List<IncidentDto> Incidents { get; set; }
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
