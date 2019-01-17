namespace FN.Store.Domain.Entities
{
    public class Produto : Entity
    {
        protected Produto() { }
        public Produto(int id, string nome, decimal precoUnitario, int categoriaId)
        {
            Id = id;
            Nome = nome;
            PrecoUnitario = precoUnitario;
            CategoriaId = categoriaId;
        }

        public Produto(string nome, decimal precoUnitario, int categoriaId)
        {
            Nome = nome;
            PrecoUnitario = precoUnitario;
            CategoriaId = categoriaId;
        }

        public string Nome { get; private set; }
        public decimal PrecoUnitario { get; private set; }
        public int CategoriaId { get; private set; }

        public void Atualizar(string nome, decimal precoUnitario, int categoriaId)
        {
            Nome = nome;
            PrecoUnitario = precoUnitario;
            CategoriaId = categoriaId;
        }
    }
}
