using FluentValidation;


namespace Lasmart.Application.Points.Commands.CreatePoint
{
    public class CreatePointCommandValidation : AbstractValidator<CreatePointCommand>
    {
        public CreatePointCommandValidation()
        {
            // Проверка полей сущности перед сохранением в БД
        }
    }
}