using LangProwess.Server.Data;
using LangProwess.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LangProwess.Server.Features.Sets;

static class PutSetById
{
	public record Command(Guid Id, Set Set) : IRequest<bool>;

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

			set.Name = request.Set.Name;
			set.Description = request.Set.Description;
			set.LastWordIndex = request.Set.LastWordIndex;
			set.QueriesLanguage = request.Set.QueriesLanguage;
			set.AnswersLanguage = request.Set.AnswersLanguage;
			set.Access = request.Set.Access;

			return await dbContext.SaveChangesAsync(cancellationToken) > 0;
		}
	}
}
