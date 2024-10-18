using TrafficManagementApi.Models;
using TrafficManagementApi.Repositories;
using System.Net;
using System.Net.Mail;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace TrafficManagementApi.Services
{
    public class IncidentNotificationService : IIncidentNotificationService
    {
        private readonly IEmergencyEndpointRepository _emergencyEndpointRepository;

        public IncidentNotificationService(IEmergencyEndpointRepository emergencyEndpointRepository)
        {
            _emergencyEndpointRepository = emergencyEndpointRepository;
        }

        public void NotifyIncident(Incident incident)
        {
            var emergencyEndpoints = _emergencyEndpointRepository.GetAllEmergencyEndpoints();

            foreach (var endpoint in emergencyEndpoints)
            {
                string message = $"Alerta de incidente: {incident.Type} em {incident.Location} às {incident.Timestamp}.";

                // Simulação de envio de notificação (substitua pela lógica real de envio)
                Console.WriteLine($"Enviando notificação para {endpoint.Name} ({endpoint.Type}): {message}");

            }
        }
    }

    public void NotifyIncident(Incident incident)
    {
        var emergencyEndpoints = _emergencyEndpointRepository.GetAllEmergencyEndpoints();

        foreach (var endpoint in emergencyEndpoints)
        {
            string message = $"Alerta de incidente: {incident.Type} em {incident.Location} às {incident.Timestamp}.";

            if (endpoint.Type == "SMS")
            {
                SendSmsNotification(endpoint.Contact, message);
            }
            else if (endpoint.Type == "Email")
            {
                SendEmailNotification(endpoint.Contact, message);
            }
            // ... (adicionar outros tipos de notificação, como API, se necessário)
        }
    }

    private void SendSmsNotification(string phoneNumber, string message)
    {
        // Substitua pelos seus dados da Twilio
        string accountSid = "SEU_ACCOUNT_SID";
        string authToken = "SEU_AUTH_TOKEN";
        string twilioPhoneNumber = "SEU_TWILIO_PHONE_NUMBER";

        TwilioClient.Init(accountSid, authToken);

        var messageOptions = new CreateMessageOptions(
            new PhoneNumber(phoneNumber))
        {
            Body = message,
            From = new PhoneNumber(twilioPhoneNumber)
        };

        var message = MessageResource.Create(messageOptions);
        Console.WriteLine(message.Sid);
    }

    private void SendEmailNotification(string emailAddress, string message)
    {
        var mailMessage = new MailMessage("seu_email@gmail.com", emailAddress)
        {
            Subject = "Alerta de Incidente",
            Body = message
        };

        var smtpClient = new SmtpClient("smtp.gmail.com")
        {
            Port = 587,
            Credentials = new NetworkCredential("seu_email@gmail.com", "sua_senha"),
            EnableSsl = true
        };

        smtpClient.Send(mailMessage);
    }
}
