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
		SetEntity.OnEntityBuilding(modelBuilder.Entity<SetEntity>());
		WordEntity.OnEntityBuilding(modelBuilder.Entity<WordEntity>());
	}

	public DbSet<UserEntity> Users => Set<UserEntity>();
	public DbSet<SetEntity> Sets => Set<SetEntity>();
	public DbSet<WordEntity> Words => Set<WordEntity>();
	public DbSet<AnswerEntity> Answers => Set<AnswerEntity>();
}
