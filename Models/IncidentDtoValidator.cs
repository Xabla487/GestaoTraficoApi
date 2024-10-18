using FluentValidation;
using TrafficManagementApi.DTOs;

namespace TrafficManagementApi.Models
{
    public class IncidentDtoValidator : AbstractValidator<IncidentDto>
    {
        public IncidentDtoValidator()
        {
            RuleFor(x => x.Type)
                .NotEmpty().WithMessage("O tipo do incidente é obrigatório.")
                .MaximumLength(100).WithMessage("O tipo do incidente não pode exceder 100 caracteres.");

            RuleFor(x => x.Location)
                .NotEmpty().WithMessage("A localização do incidente é obrigatória.")
                .MaximumLength(255).WithMessage("A localização do incidente não pode exceder 255 caracteres.");

            RuleFor(x => x.Severity)
                .NotEmpty().WithMessage("A gravidade do incidente é obrigatória.")
                .MaximumLength(50).WithMessage("A gravidade do incidente não pode exceder 50 caracteres.");

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("A descrição do incidente não pode exceder 500 caracteres.");

            RuleFor(x => x.Timestamp).NotEmpty().WithMessage("O timestamp do incidente é obrigatório.");
        }
    }
}
