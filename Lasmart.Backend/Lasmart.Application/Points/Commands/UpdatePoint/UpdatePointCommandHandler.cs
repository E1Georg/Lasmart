using Lasmart.Application.Common.Exceptions;
using Lasmart.Application.Interfaces;
using Lasmart.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace Lasmart.Application.Points.Commands.UpdatePoint
{
    public class UpdatePointCommandHandler : IRequestHandler<UpdatePointCommand, Unit>
    {
        private readonly ILasmartDbContext _dbContext;
        public UpdatePointCommandHandler(ILasmartDbContext dbContext) => _dbContext = dbContext;

        public async Task<Unit> Handle(UpdatePointCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Points.FirstOrDefaultAsync(point => point.PointID == request.ID, cancellationToken);

            if (entity == null || entity.PointID != request.ID)
                throw new EntityNotFoundException(nameof(Point), request.ID);

            entity.x = request.x;
            entity.y = request.y;
            entity.Radius = request.Radius;
            entity.Color = request.Color;

            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
