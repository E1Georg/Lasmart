using MediatR;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Lasmart.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Lasmart.Application.Comments.Queries.GetCommentList;

namespace Lasmart.Application.Points.Queries.GetPointList
{
    public class GetPointListQueryHandler : IRequestHandler<GetPointListQuery, PointListVm>
    {
        private readonly ILasmartDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetPointListQueryHandler(ILasmartDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<PointListVm> Handle(GetPointListQuery request, CancellationToken cancellationToken)
        {
            var pointsQuery = await _dbContext.Points
                .ProjectTo<PointLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var commentsQuery = await _dbContext.Comments
                .ProjectTo<CommentLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var result = new PointListVm { Points = pointsQuery };

            foreach (var item in result.Points)            
                item.Comments = commentsQuery.Where(el => el.PointID == item.ID ).ToList();            

            return result;
        }
    }
}
