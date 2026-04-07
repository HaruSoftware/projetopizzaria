using crudcomdb.Models;

namespace crudcomdb.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<List<Usuario>> Listar();
        Task<Usuario?> BuscarPorId(int id);
        Task<Usuario?> Login(string username, string senha);
        Task Salvar(Usuario usuario);
        Task Atualizar(Usuario usuario);
        Task Deletar(int id);
    }
}
