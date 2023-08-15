using MediatR;


namespace Lasmart.Application.Comments.Queries.GetCommentList
{
    public class GetCommentListQuery : IRequest<CommentListVm>
    {
        public Guid ID { get; set; }
    }
}
