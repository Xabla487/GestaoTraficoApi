namespace TrafficManagementApi.Models
{
    public class TrafficLightControl
    {
        public int TrafficLightId { get; set; } // ID do semáforo a ser controlado
        public string Action { get; set; } // Ação a ser executada (ex: "Ligar", "Desligar", "AjustarTempoCiclo")
        public int? NewCycleTime { get; set; } // Novo tempo de ciclo (opcional, usado apenas para a ação "AjustarTempoCiclo")
    }
}
