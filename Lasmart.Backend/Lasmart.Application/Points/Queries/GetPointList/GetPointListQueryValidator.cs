using FluentValidation;


namespace Lasmart.Application.Points.Queries.GetPointList
{
    public class GetPointListQueryValidator : AbstractValidator<GetPointListQuery>   
    {
        public GetPointListQueryValidator()
        {
            // Окончательная проверка запроса на валидность
        }
    }
}
