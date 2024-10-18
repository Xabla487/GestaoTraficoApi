using Microsoft.Extensions.Hosting;
using TrafficManagementApi.Services;
using TrafficManagementApi.Services.TrafficManagementApi.Services;

namespace TrafficManagementApi.BackgroundServices
{
    public class AccidentDetectionBackgroundService : BackgroundService
    {
        private readonly IAccidentDetectionService _accidentDetectionService;
        private readonly TimeSpan _interval = TimeSpan.FromMinutes(5); // Intervalo de 5 minutos

        public AccidentDetectionBackgroundService(IAccidentDetectionService accidentDetectionService)
        {
            _accidentDetectionService = accidentDetectionService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _accidentDetectionService.CheckForAccidents();
                await Task.Delay(_interval, stoppingToken);
            }
        }
    }
}
