// Services/ITrafficLightService.cs
public interface ITrafficLightService
{
    TrafficLightsViewModel GetTrafficLights(int page, int pageSize);
    // ... outros métodos do serviço
}
