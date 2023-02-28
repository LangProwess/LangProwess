using System.Reflection;
using LangProwess.Shared;
using Microsoft.AspNetCore.Mvc;

namespace LangProwess.Server.Features.Status;

[Route("api/[controller]")]
[ApiController]
public class StatusController : ControllerBase
{
	static string Version { get; } = Assembly.GetExecutingAssembly()!.GetName()!.Version!.ToString(3);

	[HttpGet("")]
	public Shared.Status Get()
		=> new(Version);
}
