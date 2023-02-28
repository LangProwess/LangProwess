using LangProwess.Server.Data;
using LangProwess.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LangProwess.Server.Features.Users;

static class GetUserById
{
	public record Query(Guid Id) : IRequest<User?>;

	public class Handler : IRequestHandler<Query, User?>
	{
		private readonly AppDbContext dbContext;

		public Handler(AppDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public async Task<User?> Handle(Query request, CancellationToken cancellationToken)
		{
			var user = await dbContext.Users.SingleOrDefaultAsync(x => x.PublicId == request.Id, cancellationToken);
			return user == null ? null : new User(user.PublicId, user.Username, user.Email, user.CreatedAt);
		}
	}
}
