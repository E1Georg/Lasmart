using FluentValidation;


namespace Lasmart.Application.Points.Commands.DeletePoint
{
    public class DeletePointCommandValidation : AbstractValidator<DeletePointCommand>
    {
        public DeletePointCommandValidation()
        {
            // Можно проверить валидность команды удаления(корректность ID записи)
        }
    }
}
