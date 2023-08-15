using AutoMapper;
using Lasmart.Application.Common.Mappings;
using Lasmart.Application.Points.Commands.CreatePoint;


namespace Lasmart.WebApi.Models.Point
{
    public class CreatePointDto : IMapWith<CreatePointCommand>
    {    
        public double x { get; set; }       
        public double y { get; set; }   
        public int Radius { get; set; }
        public string Color { get; set; }      

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreatePointDto, CreatePointCommand>()
                .ForMember(pointCommand => pointCommand.x,
                opt => opt.MapFrom(pointDto => pointDto.x))
                .ForMember(pointCommand => pointCommand.y,
                opt => opt.MapFrom(pointDto => pointDto.y))
                .ForMember(pointCommand => pointCommand.Radius,
                opt => opt.MapFrom(pointDto => pointDto.Radius))
                .ForMember(pointCommand => pointCommand.Color,
                opt => opt.MapFrom(pointDto => pointDto.Color));
        }
    }
}
