using FluentValidation;


namespace Lasmart.Application.Points.Commands.UpdatePoint
{
    public class UpdatePointCommandValidation : AbstractValidator<UpdatePointCommand>
    {
        public UpdatePointCommandValidation()
        {
            // Окончательная проверка полей сущности перед обновлением данных в БД
        }
    }
}
