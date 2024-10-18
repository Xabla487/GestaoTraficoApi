// ViewModels/TrafficLightsViewModel.cs
public class TrafficLightsViewModel
{
    public List<TrafficLightDto> TrafficLights { get; set; }
    public int TotalCount { get; set; } // Total de semáforos
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
