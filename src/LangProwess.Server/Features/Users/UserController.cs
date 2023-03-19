using LangProwess.Server.Data;
using LangProwess.Shared;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LangProwess.Server.Features.Users;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
	private readonly IMediator mediator;

	public UserController(IMediator mediator)
	{
		this.mediator = mediator;
	}

	[HttpPost("")]
	public async Task<ActionResult> AddUser([FromBody] User user)
	{
		if (user.Email == null)
		{
			return BadRequest("Email undefined");
		}

		bool updated = await mediator.Send(new AddUser.Command(user));
		return updated ? Ok() : NotFound();
	}

	[HttpGet("{id}")]
	public async Task<ActionResult<User>> GetUserById(Guid id)
	{
		var user = await mediator.Send(new GetUserById.Query(id));
		return user == null ? NotFound() : Ok(user);
	}

	[HttpDelete("{id}")]
	public async Task<ActionResult> DeleteUserById(Guid id)
	{
		bool updated = await mediator.Send(new DeleteUserById.Command(id));
		return updated ? Ok() : NotFound();
	}

	[HttpPut("{id}")]
	public async Task<ActionResult> PutUserById(Guid id, [FromBody] User user)
	{
		if (user.Email == null)
		{
			return BadRequest("Email undefined");
		}

		bool updated = await mediator.Send(new PutUserById.Command(id, user));
		return updated ? Ok() : NotFound();
	}

	[HttpGet("")]
	public async Task<ActionResult<List<User>>> GetAllUsers()
	{
		var users = await mediator.Send(new GetAllUsers.Query());
		return Ok(users);
	}
}
