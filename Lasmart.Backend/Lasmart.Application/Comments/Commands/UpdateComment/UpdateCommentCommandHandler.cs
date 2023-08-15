using Lasmart.Application.Common.Exceptions;
using Lasmart.Application.Interfaces;
using Lasmart.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace Lasmart.Application.Comments.Commands.UpdateComment
{
    public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand, Unit>
    {
        private readonly ILasmartDbContext _dbContext;
        public UpdateCommentCommandHandler(ILasmartDbContext dbContext) => _dbContext = dbContext;

        public async Task<Unit> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Comments.FirstOrDefaultAsync(comment => comment.ID == request.ID, cancellationToken);

            if (entity == null || entity.ID != request.ID)
                throw new EntityNotFoundException(nameof(Comment), request.ID);

            var point = await _dbContext.Points.FirstOrDefaultAsync(point => point.PointID == request.PointID, cancellationToken);

            if (point == null || point.PointID != request.PointID)
                throw new EntityNotFoundException(nameof(Point), request.PointID);

            entity.Text = request.Text;
            entity.BackgroundColor = request.BackgroundColor;
            entity.PointID = request.PointID;

            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
