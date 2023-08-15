using Lasmart.Application.Common.Mappings;
using Lasmart.Application.Comments.Commands.CreateComment;
using AutoMapper;


namespace Lasmart.WebApi.Models.Comment
{
    public class CreateCommentDto : IMapWith<CreateCommentCommand>
    {      
        public string Text { get; set; }
        public string BackgroundColor { get; set; }
        public Guid PointID { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateCommentDto, CreateCommentCommand>()
                .ForMember(pointCommand => pointCommand.Text,
                opt => opt.MapFrom(pointDto => pointDto.Text))
                .ForMember(pointCommand => pointCommand.BackgroundColor,
                opt => opt.MapFrom(pointDto => pointDto.BackgroundColor))
                .ForMember(pointCommand => pointCommand.PointID,
                opt => opt.MapFrom(pointDto => pointDto.PointID));
        }
    }
}
