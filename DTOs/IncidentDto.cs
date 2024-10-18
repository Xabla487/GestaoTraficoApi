namespace TrafficManagementApi.DTOs
{
    public class IncidentDto
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Location { get; set; }
        public string Severity { get; set; }
        public string Description { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
