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
	public Language NameLanguage { get; set; } = Language.SelectLanguage;
	public Language AnswersLanguage { get; set; } = Language.SelectLanguage;
	public DateTime CreatedAt { get; init; }
	public DateTime UpdatedAt { get; init; }
	public Access Access { get; set; } = Access.Personal;

	public required List<WordEntity> Words { get; set; }
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

public enum Access
{
	Personal = 0,	// self only
	LinkOnly = 1,	// link only
	Global = 2 		// public
}
