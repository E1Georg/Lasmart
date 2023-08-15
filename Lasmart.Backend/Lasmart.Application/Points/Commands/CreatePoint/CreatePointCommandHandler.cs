using MediatR;
using Lasmart.Domain;
using Lasmart.Application.Interfaces;


namespace Lasmart.Application.Points.Commands.CreatePoint
{
    internal class CreatePointCommandHandler : IRequestHandler<CreatePointCommand, Guid>
    {
        private readonly ILasmartDbContext _dbContext;
        public CreatePointCommandHandler(ILasmartDbContext dbContext) => _dbContext = dbContext;

        public async Task<Guid> Handle(CreatePointCommand request, CancellationToken cancellationToken)
        {
            var Temp = new Point
            {
                PointID = Guid.NewGuid(),
                x = request.x,
                y = request.y,
                Radius = request.Radius,
                Color = request.Color
            };

            await _dbContext.Points.AddAsync(Temp, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Temp.PointID;
        }
    }
}
