using LangProwess.Server.Data;
using LangProwess.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LangProwess.Server.Features.Sets;

static class GetSetById
{
	public record Query(Guid Id) : IRequest<Set?>;

	public class Handler : IRequestHandler<Query, Set?>
	{
		private readonly AppDbContext dbContext;

		public Handler(AppDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public async Task<Set?> Handle(Query request, CancellationToken cancellationToken)
		{
			var set = await dbContext.Sets.Include(x => x.Owner).SingleOrDefaultAsync(x => x.PublicId == request.Id, cancellationToken);


			return set == null ? null : new Set(
				set.PublicId,
				set.Name,
				set.Description,
				set.LastWordIndex,
				set.QueriesLanguage,
				set.AnswersLanguage,
				set.CreatedAt,
				set.Access,
				set.Owner.PublicId
				);
		}
	}
}
