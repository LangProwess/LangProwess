using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LangProwess.Server.Data;

class AnswerEntity
{
	public int Id { get; init; }
	public required string Name { get; init; }

	public required TermEntity ParentTerm { get; init; }
}
