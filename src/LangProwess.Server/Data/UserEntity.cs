using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LangProwess.Server.Data;

class UserEntity
{
	public int Id { get; init; }
	public Guid PublicId { get; init; } = Guid.NewGuid();
	public string? Username { get; set; }
	public required string Email { get; set; }
	public DateTimeOffset CreatedAt { get; init; }
	public DateTimeOffset UpdatedAt { get; init; }

	public List<SetEntity> Sets { get; init; } = new List<SetEntity>();

	public static void OnEntityBuilding(EntityTypeBuilder<UserEntity> builder)
	{
		builder.HasIndex(x => x.PublicId)
			.IsUnique();

		builder.HasIndex(x => x.Username)
			.IsUnique();

		builder.Property(x => x.CreatedAt)
			.CreationTimestamp();

		builder.Property(x => x.UpdatedAt)
			.UpdateTimestamp();
	}
}
