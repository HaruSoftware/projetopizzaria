using crudcomdb.Data;
using crudcomdb.Models;
using crudcomdb.Interfaces;
using Microsoft.EntityFrameworkCore;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly AppDbContext _context;

    public UsuarioRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Usuario>> Listar()
    {
        return await _context.Usuarios.ToListAsync();
    }

    public async Task<Usuario?> BuscarPorId(int id)
    {
        return await _context.Usuarios.FindAsync(id);
    }

    public async Task<Usuario?> Login(string username, string senha)
    {
        return await _context.Usuarios
            .FirstOrDefaultAsync(u => u.Username == username && u.Senha == senha);
    }

    public async Task Salvar(Usuario usuario)
    {
        _context.Usuarios.Add(usuario);
        await _context.SaveChangesAsync();
    }

    public async Task Atualizar(Usuario usuario)
    {
        _context.Usuarios.Update(usuario);
        await _context.SaveChangesAsync();
    }

    public async Task Deletar(int id)
    {
        var user = await BuscarPorId(id);
        if (user != null)
        {
            _context.Usuarios.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}