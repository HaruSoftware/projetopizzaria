using crudcomdb.Models;
using Microsoft.EntityFrameworkCore;

namespace crudcomdb.Data {
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // aqui vamos inserir as classes que representam nossas tabelas no banco de dados
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoItem> PedidoItens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Produto>().HasData(
                new Produto { Id = 1, Nome = "Pizza Calabresa", Preco = 39.90m },
                new Produto { Id = 2, Nome = "Pizza Marguerita", Preco = 42.50m },
                new Produto { Id = 3, Nome = "Pizza Frango com Catupiry", Preco = 45.00m },
                new Produto { Id = 4, Nome = "Refrigerante 2L", Preco = 12.00m },
                new Produto { Id = 5, Nome = "Pizza Portuguesa", Preco = 47.90m },
                new Produto { Id = 6, Nome = "Pizza Napolitana", Preco = 51.90m }
            );
        }
    }

}
