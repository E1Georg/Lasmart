using MediatR;


namespace Lasmart.Application.Points.Commands.UpdatePoint
{
    public class UpdatePointCommand : IRequest<Unit>
    {
        public Guid ID { get; set; }
        public double x { get; set; }
        public double y { get; set; }
        public int Radius { get; set; }
        public string Color { get; set; }
    }
}
