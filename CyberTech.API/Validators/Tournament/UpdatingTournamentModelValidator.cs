using CyberTech.API.ModelViews.Tournament;
using FluentValidation;

namespace CyberTech.API.Validators.Tournament
{
    public class UpdatingTournamentModelValidator : AbstractValidator<UpdatingTournamentModel>
    {
        public UpdatingTournamentModelValidator()
        {
            RuleFor(t => t.GameTypeId)
                .NotEqual(Guid.Empty).WithMessage("Идентификатор типа игры не может быть пустым.");

            RuleFor(t => t.TitleTournament)
                .NotEmpty().WithMessage("Название турнира не может быть пустым.")
                .Length(1, 150).WithMessage("Название турнира должно содержать от 1 до 150 символов.");

            RuleFor(t => t.TypeTournament)
                .NotEmpty().WithMessage("Тип турнира не может быть пустым.");

            // Правило неудобно для наполнения базы и генерации результатов матча

            /*RuleFor(t => t.DateTournamentInit)
                .GreaterThan(DateTime.Now).WithMessage("Дата начала турнира должна быть в будущем.");*/

            RuleFor(t => t.DateTournamentEnd)
                .GreaterThan(t => t.DateTournamentInit).WithMessage("Дата окончания турнира должна быть позже даты его начала.");

            RuleFor(t => t.PlaceName)
                .NotEmpty().WithMessage("Название места проведения не может быть пустым.");

            RuleFor(t => t.EarndTournament)
                .GreaterThanOrEqualTo(0).WithMessage("Сумма выигрыша турнира должна быть положительной или равной 0.");
        }
    }
}
