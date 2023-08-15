using MediatR;


namespace Lasmart.Application.Points.Commands.CreatePoint
{
    public class CreatePointCommand : IRequest<Guid>
    {
        public Guid ID { get; set; }
        public double x { get; set; }
        public double y { get; set; }
        public int Radius { get; set; }
        public string Color { get; set; }
    }
}
