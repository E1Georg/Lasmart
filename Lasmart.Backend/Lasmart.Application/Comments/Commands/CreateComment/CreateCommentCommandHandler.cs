using MediatR;
using Lasmart.Domain;
using Lasmart.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Lasmart.Application.Common.Exceptions;

namespace Lasmart.Application.Comments.Commands.CreateComment
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, Guid>
    {
        private readonly ILasmartDbContext _dbContext;
        public CreateCommentCommandHandler(ILasmartDbContext dbContext) => _dbContext = dbContext;

        public async Task<Guid> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Points.FirstOrDefaultAsync(point => point.PointID == request.PointID, cancellationToken);

            if (entity == null || entity.PointID != request.PointID)
                throw new EntityNotFoundException(nameof(Point), request.PointID);

            var Temp = new Comment
            {
                ID = Guid.NewGuid(),
                Text = request.Text,
                BackgroundColor = request.BackgroundColor,
                PointID = request.PointID
            };

            await _dbContext.Comments.AddAsync(Temp, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Temp.ID;
        }
    }
}
