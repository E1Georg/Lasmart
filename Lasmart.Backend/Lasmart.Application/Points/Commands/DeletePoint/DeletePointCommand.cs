using MediatR;


namespace Lasmart.Application.Points.Commands.DeletePoint
{
    public class DeletePointCommand : IRequest<Unit>
    {
        public Guid ID { get; set; }
    }
}