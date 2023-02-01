using Microsoft.EntityFrameworkCore;

namespace LangProwess;

class AppDbContext : DbContext
{
	public AppDbContext(IHostEnvironment environment)
		// TODO: Make configurable
		=> DbPath = Path.Join(environment.ContentRootPath, "local", "app.db");

	private string DbPath { get; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		=> optionsBuilder.UseSqlite($"Data Source={DbPath}");
}
