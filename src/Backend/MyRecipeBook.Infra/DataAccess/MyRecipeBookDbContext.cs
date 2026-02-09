using Microsoft.EntityFrameworkCore;
namespace MyRecipeBook.Infra.DataAccess;

public class MyRecipeBookDbContext : DbContext
{
    // Construtor que recebe as opções de configuração do DbContext
    public MyRecipeBookDbContext(DbContextOptions options) : base(options) { }

    // Falando para entity framework que a entidade User é uma tabela do banco de dados
    public DbSet<Domain.Entities.User> Users { get; set; }

    // Configurações adicionais do modelo
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MyRecipeBookDbContext).Assembly);
    }
}

