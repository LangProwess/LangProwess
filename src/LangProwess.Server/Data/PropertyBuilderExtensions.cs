using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LangProwess.Server.Data;

static class PropertyBuilderExtensions
{
	public static PropertyBuilder<T> CreationTimestamp<T>(this PropertyBuilder<T> property)
		=> property.HasDefaultValueSql("CURRENT_TIMESTAMP").ValueGeneratedOnAdd();

	public static PropertyBuilder<T> UpdateTimestamp<T>(this PropertyBuilder<T> property)
		=> property.HasDefaultValueSql("CURRENT_TIMESTAMP").ValueGeneratedOnAddOrUpdate();
}
