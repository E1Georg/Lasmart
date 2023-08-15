using FluentValidation;


namespace Lasmart.Application.Comments.Commands.UpdateComment
{
    public class UpdateCommentCommandValidation : AbstractValidator<UpdateCommentCommand>
    {
        public UpdateCommentCommandValidation()
        {
            // Окончательная проверка полей сущности перед обновлением данных в БД
        }
    }
}
