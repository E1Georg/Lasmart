using MediatR;


namespace Lasmart.Application.Comments.Commands.DeleteComment
{
    public class DeleteCommentCommand : IRequest<Unit>
    {
        public Guid ID { get; set; }
    }
}