using MediatR;


namespace Lasmart.Application.Comments.Commands.CreateComment
{
    public class CreateCommentCommand : IRequest<Guid>
    {
        public Guid ID { get; set; }
        public string Text { get; set; }
        public string BackgroundColor { get; set; }
        public Guid PointID { get; set; }
    }
}
