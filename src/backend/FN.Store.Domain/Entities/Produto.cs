namespace FN.Store.Domain.Entities
{
    public class Produto: Entity
    {
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

       protected Produto(){}

        public string Nome { get; private set; }
        public decimal PrecoUnitario { get; private set; }
        public int CategoriaId { get; private set; }
    }
}
