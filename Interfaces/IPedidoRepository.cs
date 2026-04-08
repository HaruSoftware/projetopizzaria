using crudcomdb.Models;

namespace crudcomdb.Interfaces
{
    public interface IPedidoRepository
    {
        Task Criar(Pedido pedido);
        Task<List<Pedido>> Listar();
        Task<Pedido?> ObterPorId(int id);
    }
}
