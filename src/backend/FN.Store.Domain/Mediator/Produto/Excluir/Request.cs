using MediatR;

namespace FN.Store.Domain.Mediator.Produto.Excluir
{
    public class Request : IRequest<Response>
    {
        public int Id { get; set; }
    }
}
