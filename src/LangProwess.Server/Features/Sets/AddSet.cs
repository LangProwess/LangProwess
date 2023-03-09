using LangProwess.Server.Data;
using LangProwess.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LangProwess.Server.Features.Sets;

static class AddSet
{
	public record Command(Set Set) : IRequest<bool>;

	public class Handler : IRequestHandler<Command, bool>
	{
		private readonly AppDbContext dbContext;

		public Handler(AppDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public async Task<bool> Handle(Command request, CancellationToken cancellationToken)
		{
			var owner = await dbContext.Users.SingleOrDefaultAsync(x => x.PublicId == request.Set.OwnerId, cancellationToken);

			if (owner == null)
			{
				return false;
			}

			var set = new SetEntity
			{
				Name = request.Set.Name,
				Description = request.Set.Description,
				LastWordIndex = request.Set.LastWordIndex,
				QueriesLanguage = request.Set.QueriesLanguage,
				AnswersLanguage = request.Set.AnswersLanguage,
				Access = request.Set.Access,
				Owner = owner,
			};

			await dbContext.Sets.AddAsync(set, cancellationToken);

			owner.Sets.Add(set);

			return await dbContext.SaveChangesAsync(cancellationToken) > 0;
		}
	}
}
