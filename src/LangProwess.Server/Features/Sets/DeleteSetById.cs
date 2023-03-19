using LangProwess.Server.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LangProwess.Server.Features.Sets;

static class DeleteSetById
{
	public record Command(Guid Id) : IRequest<bool>;

	public class Handler : IRequestHandler<Command, bool>
	{
		private readonly AppDbContext dbContext;

		public Handler(AppDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public async Task<bool> Handle(Command request, CancellationToken cancellationToken)
		{
			var set = await dbContext.Sets.SingleOrDefaultAsync(x => x.PublicId == request.Id, cancellationToken);

			if (set == null)
			{
				return false;
			}

			dbContext.Sets.Remove(set);
			return await dbContext.SaveChangesAsync(cancellationToken) > 0;
		}
	}
}
