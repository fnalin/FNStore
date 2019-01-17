using MediatR;

namespace FN.Store.Domain.Mediator.Produto.Atualizar
{
    public class Request : IRequest<Response>
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal PrecoUnitario { get; set; }
        public int CategoriaId { get; set; }
    }
}
