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
    }

}
