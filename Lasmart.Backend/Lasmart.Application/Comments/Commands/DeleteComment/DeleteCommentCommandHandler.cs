using Lasmart.Application.Common.Exceptions;
using Lasmart.Application.Interfaces;
using Lasmart.Domain;
using MediatR;


namespace Lasmart.Application.Comments.Commands.DeleteComment
{
    public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand, Unit>
    {
        private readonly ILasmartDbContext _dbContext;
        public DeleteCommentCommandHandler(ILasmartDbContext dbContext) => _dbContext = dbContext;

        public async Task<Unit> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Comments.FindAsync(new object[] { request.ID }, cancellationToken);

            if (entity == null || entity.ID != request.ID)
                throw new EntityNotFoundException(nameof(Comment), request.ID);

            _dbContext.Comments.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
