using LangProwess.Server.Features.Sets;
using LangProwess.Shared;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LangProwess.Server.Features;
[Route("api/[controller]")]
[ApiController]
public class SetController : ControllerBase
{
	private readonly IMediator mediator;

	public SetController(IMediator mediator)
	{
		this.mediator = mediator;
	}

	[HttpPost("")]
	public async Task<ActionResult> AddSet([FromBody] Set set)
	{
		bool updated = await mediator.Send(new AddSet.Command(set));
		return updated ? Ok() : NotFound();
	}

	[HttpGet("{id}")]
	public async Task<ActionResult<Set>> GetSetById(Guid id)
	{
		var set = await mediator.Send(new GetSetById.Query(id));
		return set == null ? NotFound() : Ok(set);
	}

	[HttpGet("")]
	public async Task<ActionResult<List<Set>>> GetAllSets()
	{
		var sets = await mediator.Send(new GetAllSets.Query());
		return Ok(sets);
	}

	[HttpPut("{id}")]
	public async Task<ActionResult>PutSetById([FromBody] Set set, Guid id)
	{
		bool updated = await mediator.Send(new PutSetById.Command(id, set));
		return updated ? Ok() : NotFound();
	}

	[HttpDelete("{id}")]
	public async Task<ActionResult> DeleteSetById(Guid id)
	{
		bool updated = await mediator.Send(new DeleteSetById.Command(id));
		return updated ? Ok() : NotFound();
	}
}
