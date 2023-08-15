using FluentValidation;


namespace Lasmart.Application.Comments.Commands.DeleteComment
{
    public class DeleteCommentCommandValidation : AbstractValidator<DeleteCommentCommand>
    {
        public DeleteCommentCommandValidation()
        {
            // Можно проверить валидность команды удаления(корректность ID записи)
        }
    }
}
