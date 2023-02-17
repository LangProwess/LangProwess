using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LangProwess.Server.Data;

class WordEntity
{
	public int Id { get; init; }
	public Guid PublicId { get; init; } = Guid.NewGuid();
	public required string Name { get; set; }
	public string? Definition { get; set; } // Descriptive definition
	public string? Pronounciation { get; set; }
	public DateTime CreatedAt { get; init; }
	public DateTime UpdatedAt { get; init; }
	public Progress Progress { get; set; } = Progress.ToLearn;

	public required SetEntity Set { get; init; }
	public required List<AnswerEntity> Answers { get; init; } // Acceptable responses

	public static void OnEntityBuilding(EntityTypeBuilder<WordEntity> builder)
	{
		builder.HasIndex(x => x.PublicId)
			.IsUnique();

		builder.HasIndex(x => x.Name);

		builder.Property(x => x.CreatedAt)
			.CreationTimestamp();

		builder.Property(x => x.UpdatedAt)
			.UpdateTimestamp();
	}
}

enum Progress
{
	ToLearn = 0,
	Learning = 1,
	Learned = 2
}
