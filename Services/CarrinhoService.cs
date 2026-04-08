using crudcomdb.Models;

namespace crudcomdb.Services
{
    public class CarrinhoService
    {
        public List<CarrinhoItem> Itens { get; set; } = new();

        public event Action OnChange;

        public void Adicionar(Produto produto)
        {
            var item = Itens.FirstOrDefault(x => x.Produto.Id == produto.Id);

            if (item != null)
                item.Quantidade++;
            else
                Itens.Add(new CarrinhoItem { Produto = produto, Quantidade = 1 });

            Notificar();
        }

        public void Remover(int produtoId)
        {
            var item = Itens.FirstOrDefault(x => x.Produto.Id == produtoId);
            if (item != null)
            {
                Itens.Remove(item);
                Notificar();
            }
        }

        public void Aumentar(int produtoId)
        {
            var item = Itens.FirstOrDefault(x => x.Produto.Id == produtoId);
            if (item != null)
            {
                item.Quantidade++;
                Notificar();
            }
        }

        public void Diminuir(int produtoId)
        {
            var item = Itens.FirstOrDefault(x => x.Produto.Id == produtoId);
            if (item != null)
            {
                item.Quantidade--;

                if (item.Quantidade <= 0)
                    Itens.Remove(item);

                Notificar();
            }
        }

        public decimal Total()
        {
            return Itens.Sum(x => x.Produto.Preco * x.Quantidade);
        }

        private void Notificar() => OnChange?.Invoke();
    }
}
