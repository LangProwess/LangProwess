using LangProwess.Server.Data;
using LangProwess.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LangProwess.Server.Features.Users;

static class UpdateUserById
{
	public record Command(Guid Id, User User) : IRequest<bool>;

	public class Handler : IRequestHandler<Command, bool>
	{
		private readonly AppDbContext dbContext;

		public Handler(AppDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public async Task<bool> Handle(Command request, CancellationToken cancellationToken)
		{
			var user = await dbContext.Users.SingleOrDefaultAsync(x => x.PublicId == request.Id, cancellationToken);

			if (user == null)
			{
				return false;
			}

			user.Username = request.User.Username;
			user.Email = request.User.Email!;

			return await dbContext.SaveChangesAsync(cancellationToken) > 0;
		}
	}
}
