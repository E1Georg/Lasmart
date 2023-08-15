using MediatR;


namespace Lasmart.Application.Comments.Commands.UpdateComment
{
    public class UpdateCommentCommand : IRequest<Unit>
    {
        public Guid ID { get; set; }
        public string Text { get; set; }
        public string BackgroundColor { get; set; }
        public Guid PointID { get; set; }
    }
}
