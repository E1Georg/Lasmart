using AutoMapper;
using Lasmart.Application.Common.Mappings;
using Lasmart.Domain;


namespace Lasmart.Application.Comments.Queries.GetCommentList
{
    public class CommentLookupDto : IMapWith<Comment>
    {
        public Guid ID { get; set; }
        public Guid PointID { get; set; }
        public string Text { get; set; }
        public string BackgroundColor { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Comment, CommentLookupDto>()
                .ForMember(commentDto => commentDto.ID,
                opt => opt.MapFrom(comment => comment.ID))
                .ForMember(commentDto => commentDto.PointID,
                opt => opt.MapFrom(comment => comment.PointID))
                .ForMember(commentDto => commentDto.Text,
                opt => opt.MapFrom(comment => comment.Text))
                .ForMember(commentDto => commentDto.BackgroundColor,
                opt => opt.MapFrom(comment => comment.BackgroundColor));
        }
    }
}
