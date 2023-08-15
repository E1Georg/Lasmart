using AutoMapper;
using Lasmart.Application.Common.Mappings;
using Lasmart.Application.Comments.Commands.UpdateComment;

namespace Lasmart.WebApi.Models.Comment
{
    public class UpdateCommentDto : IMapWith<UpdateCommentCommand>
    {
        public Guid ID { get; set; }
        public string Text { get; set; }
        public string BackgroundColor { get; set; }
        public Guid? PointID { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateCommentDto, UpdateCommentCommand>()
                .ForMember(pointCommand => pointCommand.ID,
                opt => opt.MapFrom(pointDto => pointDto.ID))
                .ForMember(pointCommand => pointCommand.Text,
                opt => opt.MapFrom(pointDto => pointDto.Text))
                .ForMember(pointCommand => pointCommand.BackgroundColor,
                opt => opt.MapFrom(pointDto => pointDto.BackgroundColor))
                .ForMember(pointCommand => pointCommand.PointID,
                opt => opt.MapFrom(pointDto => pointDto.PointID));
        }
    }
}
