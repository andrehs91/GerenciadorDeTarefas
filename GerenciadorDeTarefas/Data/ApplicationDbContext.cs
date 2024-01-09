using GerenciadorDeTarefas.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorDeTarefas.Data;

public class ApplicationDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration)
    : base(options)
    {
        _configuration = configuration;
    }

    public DbSet<Tarefa> Tarefas { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
    {
        dbContextOptionsBuilder.UseSqlServer(_configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("App");
    }
}
