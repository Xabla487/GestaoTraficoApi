using TrafficManagementApi.DTOs;
using TrafficManagementApi.Models;
using TrafficManagementApi.Repositories;
using TrafficManagementApi.ViewModels;

namespace TrafficManagementApi.Services
{
    public class TrafficLightService : ITrafficLightService
    {
        private readonly ITrafficLightRepository _trafficLightRepository;

        public TrafficLightService(ITrafficLightRepository trafficLightRepository)
        {
            _trafficLightRepository = trafficLightRepository;
        }

        public TrafficLightsViewModel GetTrafficLights(int page, int pageSize)
        {
            var trafficLights = _trafficLightRepository.GetTrafficLights(page, pageSize);
            var totalCount = _trafficLightRepository.GetTotalCount();

            return new TrafficLightsViewModel
            {
                TrafficLights = trafficLights.Select(tl => new TrafficLightDto
                {
                    Id = tl.Id,
                    Location = tl.Location,
                    Status = tl.Status,
                    CycleTime = tl.CycleTime
                }).ToList(),
                TotalCount = totalCount,
                PageNumber = page,
                PageSize = pageSize
            };
        }

        public bool ControlTrafficLight(int id, TrafficLightControl trafficLightControl)
        {
            var trafficLight = _trafficLightRepository.GetTrafficLightById(id);
            if (trafficLight == null)
            {
                return false;
            }

            // Validação da ação de controle e parâmetros
            if (!IsValidAction(trafficLightControl.Action))
            {
                return false; // Ação inválida
            }

            if (trafficLightControl.Action == "AjustarTempoCiclo" && (trafficLightControl.NewCycleTime == null || trafficLightControl.NewCycleTime <= 0))
            {
                return false; // Novo tempo de ciclo inválido
            }

            // Lógica de controle (simulação)
            switch (trafficLightControl.Action)
            {
                case "Ligar":
                    trafficLight.Status = "Verde"; // Ou outro estado inicial
                    break;
                case "Desligar":
                    trafficLight.Status = "Desligado";
                    break;
                case "AjustarTempoCiclo":
                    trafficLight.CycleTime = trafficLightControl.NewCycleTime.Value;
                    break;
            }

            _trafficLightRepository.SaveChanges();
            return true;
        }

        private bool IsValidAction(string action)
        {
            // Verificar se a ação é válida (ex: "Ligar", "Desligar", "AjustarTempoCiclo")
            return action == "Ligar" || action == "Desligar" || action == "AjustarTempoCiclo"; // ...
        }


        public TrafficFlowData GetTrafficFlowData(string? location, DateTime? startDate, DateTime? endDate)
        {
            var trafficFlows = _trafficLightRepository.GetTrafficFlowData(location, startDate, endDate);

            return new TrafficFlowData
            {
                TrafficFlows = trafficFlows.Select(tf => new TrafficFlowDto
                {
                    Location = tf.Location,
                    Timestamp = tf.Timestamp,
                    VehicleCount = tf.VehicleCount,
                    AverageSpeed = tf.AverageSpeed
                }).ToList()
            };
        }

    }
}
