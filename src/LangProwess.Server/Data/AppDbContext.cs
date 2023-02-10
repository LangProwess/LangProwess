using Microsoft.EntityFrameworkCore;

namespace LangProwess.Server.Data;

class AppDbContext : DbContext
{
	public AppDbContext(IHostEnvironment environment)
		// TODO: Make configurable
		=> DbPath = Path.Join(environment.ContentRootPath, "local", "app.db");

	private string DbPath { get; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		=> optionsBuilder.UseSqlite($"Data Source={DbPath}");

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		UserEntity.OnEntityBuilding(modelBuilder.Entity<UserEntity>());
	}
}
