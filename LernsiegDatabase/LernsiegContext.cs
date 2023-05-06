using LernsiegDatabase.Entities;
using Microsoft.EntityFrameworkCore;

namespace LernsiegDatabase;

public class LernsiegContext : DbContext
{
    public DbSet<School> Schools { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Evaluation> Evaluations { get; set; }
    public DbSet<EvaluationItem> EvaluationItems { get; set; }
    public DbSet<Criteria> Criterias { get; set; }

    public LernsiegContext(DbContextOptions<LernsiegContext> options) : base(options)
    {
    }

    public LernsiegContext()
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlite("data source=lernsieg.sqlite3");
        }
    }
}
