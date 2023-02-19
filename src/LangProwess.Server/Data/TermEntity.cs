using System.ComponentModel;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LangProwess.Server.Data;

class TermEntity // Pair of Queries and Answers
{
	public int Id { get; init; }
	public Guid PublicId { get; init; } = Guid.NewGuid();
	public string? Definition { get; set; } // Descriptive definition
	public string? Pronounciation { get; set; }
	public DateTimeOffset CreatedAt { get; init; }
	public DateTimeOffset UpdatedAt { get; init; }
	public Progress Progress { get; set; } = Progress.ToLearn;

	public required SetEntity Set { get; init; }
	public required List<QueryEntity> Queries { get; init; } 
	public required List<AnswerEntity> Answers { get; init; }

	public static void OnEntityBuilding(EntityTypeBuilder<TermEntity> builder)
	{
		builder.HasIndex(x => x.PublicId)
			.IsUnique();

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
