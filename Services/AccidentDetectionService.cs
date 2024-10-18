using TrafficManagementApi.Models;
using TrafficManagementApi.Repositories;

namespace TrafficManagementApi.Services
{
    namespace TrafficManagementApi.Services
    {
        public class AccidentDetectionService : IAccidentDetectionService
        {
            private readonly ITrafficLightRepository _trafficLightRepository;
            private readonly IIncidentRepository _incidentRepository;
            private readonly IIncidentNotificationService _incidentNotificationService; // Adicionar a injeção de dependência

            public AccidentDetectionService()
            {
            }

            public AccidentDetectionService(
                ITrafficLightRepository trafficLightRepository,
                IIncidentRepository incidentRepository,
                IIncidentNotificationService incidentNotificationService)
            {
                _trafficLightRepository = trafficLightRepository;
                _incidentRepository = incidentRepository;
                _incidentNotificationService = incidentNotificationService; // Inicializar a dependência
            }

            public void CheckForAccidents()
            {
                var trafficFlows = _trafficLightRepository.GetRecentTrafficFlowData();

                foreach (var trafficFlow in trafficFlows)
                {
                    if (IsAccidentDetected(trafficFlow))
                    {
                        var incident = new Incident
                        {
                            Type = "Acidente",
                            Location = trafficFlow.Location,
                            Severity = "Grave", // Ou calcular a gravidade com base nos dados
                            Description = "Acidente detectado automaticamente.",
                            Timestamp = DateTime.Now
                        };

                        _incidentRepository.AddIncident(incident);
                        _incidentRepository.SaveChanges();

                        // Enviar notificação
                        _incidentNotificationService.NotifyIncident(incident); // Chamar o serviço de notificação
                    }
                }
            }

            private bool IsAccidentDetected(TrafficFlow trafficFlow)
            {

                if (trafficFlow.VehicleCount > 10 && trafficFlow.AverageSpeed < 10)
                {
                    return true;
                }

                return false;
            }
        }
    }
}
