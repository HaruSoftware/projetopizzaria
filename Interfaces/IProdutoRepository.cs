using crudcomdb.Models;

namespace crudcomdb.Interfaces
{
    public interface IProdutoRepository
    {
        Task<List<Produto>> Listar();
        Task<Produto?> BuscarPorId(int id);
        Task Salvar(Produto produto);
        Task Atualizar(Produto produto);
        Task Deletar(int id);
    }
}
