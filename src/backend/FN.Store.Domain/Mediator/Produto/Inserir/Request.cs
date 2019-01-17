using MediatR;

namespace FN.Store.Domain.Mediator.Produto.Inserir
{
    public class Request: IRequest<Response>
    {
        public string Nome { get; set; }
        public decimal PrecoUnitario { get; set; }
        public int CategoriaId { get; set; }
    }
}
