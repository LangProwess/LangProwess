using LangProwess.Server.Data;
using LangProwess.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LangProwess.Server.Features.Users;

static class DeleteUserById
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
			var user = await dbContext.Users.SingleOrDefaultAsync(x => x.PublicId == request.Id, cancellationToken);

			if (user == null)
			{
				return false;
			}

			dbContext.Users.Remove(user);
			return await dbContext.SaveChangesAsync(cancellationToken) > 0;
					
		}
	}
}
