using LangProwess.Server.Data;
using LangProwess.Shared;
using MediatR;

namespace LangProwess.Server.Features.Users;

// Will be outsourced to Auth
static class AddUser
{
	public record Command(User User) : IRequest<bool>;

	public class Handler : IRequestHandler<Command, bool>
	{
		private readonly AppDbContext dbContext;

		public Handler(AppDbContext dbContext)
		{ 
			this.dbContext = dbContext;
		}	

		public async Task<bool> Handle(Command request, CancellationToken cancellationToken)
		{
			
			await dbContext.Users.AddAsync(new UserEntity
			{
				Username = request.User.Username,
				Email = request.User.Email!
			}, cancellationToken);

			return await dbContext.SaveChangesAsync(cancellationToken) > 0;
		}
	}
}
