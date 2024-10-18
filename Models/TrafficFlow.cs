namespace TrafficManagementApi.Models
{
    public class TrafficFlow
    {
        public int Id { get; set; }
        public string Location { get; set; } // Localização do sensor ou ponto de coleta de dados
        public DateTime Timestamp { get; set; }
        public int VehicleCount { get; set; } // Número de veículos detectados
        public double AverageSpeed { get; set; } // Velocidade média dos veículos
    }
}
