using FluentValidation;


namespace Lasmart.Application.Comments.Queries.GetCommentList
{
    public class GetCommentListQueryValidator : AbstractValidator<GetCommentListQuery>
    {
        public GetCommentListQueryValidator()
        {
            // Окончательная проверка запроса на валидность
        }
    }
}
