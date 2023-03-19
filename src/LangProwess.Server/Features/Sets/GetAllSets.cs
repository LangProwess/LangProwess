using LangProwess.Server.Data;
using LangProwess.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LangProwess.Server.Features.Sets;

static class GetAllSets
{
	public record Query() : IRequest<List<Set>>;

	public class Handler : IRequestHandler<Query, List<Set>>
	{
		private readonly AppDbContext dbContext;

		public Handler(AppDbContext dbContext)
		{ 
			this.dbContext = dbContext;
		}

		public async Task<List<Set>> Handle(Query request, CancellationToken cancellationToken)
		{
			var setsData = await dbContext.Sets.Include(x => x.Owner).ToListAsync(cancellationToken);
			List<Set> sets = new List<Set>();

			foreach(var setData in setsData)
			{
				sets.Add(new Set
				(
					setData.PublicId,
					setData.Name,
					setData.Description,
					setData.LastWordIndex,
					setData.QueriesLanguage,
					setData.AnswersLanguage,
					setData.CreatedAt,
					setData.Access,
					setData.Owner.PublicId
				));
			}

			return sets;
		}
	}
}
