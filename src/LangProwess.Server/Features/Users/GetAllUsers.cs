using LangProwess.Server.Data;
using LangProwess.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LangProwess.Server.Features.Users;

static class GetAllUsers
{
	public record Query() : IRequest<List<User>>;

	public class Handler : IRequestHandler<Query, List<User>>
	{
		private readonly AppDbContext dbContext;

		public Handler(AppDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public async Task<List<User>> Handle(Query request, CancellationToken cancellationToken)
		{
			var usersData = await dbContext.Users.ToListAsync(cancellationToken);
			List<User> users = new List<User>();

			foreach(var userData in usersData)
			{
				users.Add(new User
				(
					userData.PublicId,
					userData.Username,
					userData.Email,
					userData.CreatedAt
				));
			}
			return users;
		}
	}
}
