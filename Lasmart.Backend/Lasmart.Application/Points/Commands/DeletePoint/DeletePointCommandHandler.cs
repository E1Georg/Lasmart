using Lasmart.Application.Common.Exceptions;
using Lasmart.Application.Interfaces;
using Lasmart.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Lasmart.Application.Points.Commands.DeletePoint
{
    public class DeletePointCommandHandler : IRequestHandler<DeletePointCommand, Unit>
    {
        private readonly ILasmartDbContext _dbContext;
        public DeletePointCommandHandler(ILasmartDbContext dbContext) => _dbContext = dbContext;

        public async Task<Unit> Handle(DeletePointCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Points.FindAsync(new object[] { request.ID }, cancellationToken);

            if (entity == null || entity.PointID != request.ID)
                throw new EntityNotFoundException(nameof(Point), request.ID);

            var comments = _dbContext.Comments.Where(x => x.PointID == entity.PointID).ToList();
            entity.Comments = comments;

            _dbContext.Points.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}