using MediatR;


namespace Lasmart.Application.Points.Queries.GetPointList
{
    public class GetPointListQuery : IRequest<PointListVm>
    {
        public Guid ID { get; set; }
    }
}
