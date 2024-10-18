namespace TrafficManagementApi.DTOs
{
    public class TrafficFlowDto
    {
        public string Location { get; set; }
        public DateTime Timestamp { get; set; }
        public int VehicleCount { get; set; }
        public double AverageSpeed { get; set; }
    }
}
