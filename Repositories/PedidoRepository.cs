using crudcomdb.Data;
using crudcomdb.Interfaces;
using crudcomdb.Models;
using Microsoft.EntityFrameworkCore;

public class PedidoRepository : IPedidoRepository
{
    private readonly AppDbContext _context;

    public PedidoRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task Criar(Pedido pedido)
    {
        _context.Pedidos.Add(pedido);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Pedido>> Listar()
    {
        return await _context.Pedidos
            .Include(p => p.Itens)
                .ThenInclude(i => i.Produto)
            .ToListAsync();
    }
    public async Task<Pedido?> ObterPorId(int id)
    {
        return await _context.Pedidos
            .Include(p => p.Itens)
                .ThenInclude(i => i.Produto)
            .FirstOrDefaultAsync(p => p.Id == id);
    }
}
