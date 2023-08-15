using FluentValidation;


namespace Lasmart.Application.Comments.Commands.CreateComment
{
    public class CreateCommentCommandValidation : AbstractValidator<CreateCommentCommand>
    {
        public CreateCommentCommandValidation()
        {
            // Проверка полей сущности перед сохранением в БД
        }
    }
}
