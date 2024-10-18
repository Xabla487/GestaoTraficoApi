namespace TrafficManagementApi.Models
{
    public class EmergencyEndpoint
    {
        public int Id { get; set; }
        public string Name { get; set; } // Nome do contato ou serviço (ex: "Polícia Rodoviária", "SAMU")
        public string Type { get; set; } // Tipo de serviço (ex: "Polícia", "Bombeiros", "Ambulância")
        public string Contact { get; set; } // Telefone, email ou URL da API
    }
}
