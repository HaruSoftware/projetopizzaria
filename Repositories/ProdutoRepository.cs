using crudcomdb.Data;
using crudcomdb.Models;
using crudcomdb.Interfaces;
using Microsoft.EntityFrameworkCore;

public class ProdutoRepository : IProdutoRepository
{
    private readonly AppDbContext _context;

    public ProdutoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Produto>> Listar()
    {
        return await _context.Produtos.ToListAsync();
    }

    public async Task<Produto?> BuscarPorId(int id)
    {
        return await _context.Produtos.FindAsync(id);
    }

    public async Task Salvar(Produto produto)
    {
        _context.Produtos.Add(produto);
        await _context.SaveChangesAsync();
    }

    public async Task Atualizar(Produto produto)
    {
        _context.Produtos.Update(produto);
        await _context.SaveChangesAsync();
    }

    public async Task Deletar(int id)
    {
        var produto = await BuscarPorId(id);
        if (produto != null)
        {
            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
        }
    }
}