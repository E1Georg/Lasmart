using AutoMapper;
using Lasmart.Application.Comments.Queries.GetCommentList;
using Lasmart.Application.Common.Mappings;
using Lasmart.Domain;


namespace Lasmart.Application.Points.Queries.GetPointList
{
    public class PointLookupDto : IMapWith<Point>
    {
        public Guid ID { get; set; }
        public double x { get; set; }
        public double y { get; set; }
        public int Radius { get; set; }
        public string Color { get; set; }
        
        public List<CommentLookupDto>? Comments { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Point, PointLookupDto>()
                .ForMember(pointDto => pointDto.ID,
                opt => opt.MapFrom(point => point.PointID))
                .ForMember(pointDto => pointDto.x,
                opt => opt.MapFrom(point => point.x))
                .ForMember(pointDto => pointDto.y,
                opt => opt.MapFrom(point => point.y))
                .ForMember(pointDto => pointDto.Radius,
                opt => opt.MapFrom(point => point.Radius))
                 .ForMember(pointDto => pointDto.Color,
                opt => opt.MapFrom(point => point.Color));
        }
    }
}
