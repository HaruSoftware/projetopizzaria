namespace crudcomdb.Models
{
    public class Pedido
    {
        public int Id { get; set; }

        public int IdCliente { get; set; }

        public DateTime Data { get; set; } = DateTime.Now;

        public decimal Total { get; set; }

        public StatusPedido Status { get; set; } = StatusPedido.Pendente;

        public bool Pago { get; set; } = false;

        public List<PedidoItem> Itens { get; set; } = new();
    }
}
namespace crudcomdb.Models
{
    public enum StatusPedido
    {
        Pendente = 0,
        EmPreparo = 1,
        SaiuParaEntrega = 2,
        Entregue = 3,
        Cancelado = 4
    }
}