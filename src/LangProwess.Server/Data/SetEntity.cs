using LangProwess.Shared;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LangProwess.Server.Data;

class SetEntity
{
	public int Id { get; init; }
	public Guid PublicId { get; init; } = Guid.NewGuid();
	public required string Name { get; set; }
	public string? Description { get; set; }
	public int? LastWordIndex { get; set; } 
	public Language QueriesLanguage { get; set; } = Language.SelectLanguage;
	public Language AnswersLanguage { get; set; } = Language.SelectLanguage;
	public DateTimeOffset CreatedAt { get; init; }
	public DateTimeOffset UpdatedAt { get; init; }
	public SetAccess Access { get; set; } = SetAccess.Personal;

	public List<TermEntity> Terms { get; set; } = new List<TermEntity>();
	public required UserEntity Owner { get; init; }

	public static void OnEntityBuilding(EntityTypeBuilder<SetEntity> builder)
	{
		builder.HasIndex(x => x.PublicId)
			.IsUnique();

		builder.HasIndex(x => x.Name)
			.IsUnique();

		builder.Property(x => x.CreatedAt)
			.CreationTimestamp();

		builder.Property(x => x.UpdatedAt)
			.UpdateTimestamp();
	}
}
