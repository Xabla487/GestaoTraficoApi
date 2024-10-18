// Models/TrafficLight.cs
public class TrafficLight
{
    public int Id { get; set; }
    public string Location { get; set; }
    public string Status { get; set; } // Ex: "Verde", "Amarelo", "Vermelho"
    public int CycleTime { get; set; } // Em segundos
    // ... outras propriedades relevantes
}
