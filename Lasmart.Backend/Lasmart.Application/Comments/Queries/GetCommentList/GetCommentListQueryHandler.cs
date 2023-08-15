using MediatR;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Lasmart.Application.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace Lasmart.Application.Comments.Queries.GetCommentList
{
    public class GetCommentListQueryHandler : IRequestHandler<GetCommentListQuery, CommentListVm>
    {
        private readonly ILasmartDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetCommentListQueryHandler(ILasmartDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<CommentListVm> Handle(GetCommentListQuery request, CancellationToken cancellationToken)
        {
            var commentsQuery = await _dbContext.Comments
                .ProjectTo<CommentLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new CommentListVm { Comments = commentsQuery };
        }
    }
}
