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
		TermEntity.OnEntityBuilding(modelBuilder.Entity<TermEntity>());
	}

	public DbSet<UserEntity> Users => Set<UserEntity>();
	public DbSet<SetEntity> Sets => Set<SetEntity>();
	public DbSet<TermEntity> Terms => Set<TermEntity>();
	public DbSet<QueryEntity> Queries => Set<QueryEntity>();
	public DbSet<AnswerEntity> Answers => Set<AnswerEntity>();
}
