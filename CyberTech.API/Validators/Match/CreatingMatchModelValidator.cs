using CyberTech.API.ModelViews.Match;
using CyberTech.API.ModelViews.Tournament;
using FluentValidation;

namespace CyberTech.API.Validators.Match
{
    public class CreatingMatchModelValidator : AbstractValidator<CreatingMatchModel>
    {
        public CreatingMatchModelValidator()
        {
            RuleFor(t => t.FirstTeamId)
                .NotEqual(t => t.SecondTeamId).WithMessage("Соперниками в матче должны быть разные команды");

        }
    }
}
