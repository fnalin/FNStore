using FN.Store.Domain.Contracts.Infra.Data;
using FN.Store.Domain.Contracts.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FN.Store.Domain.Mediator.Produto.Inserir
{
    public class Handler : IRequestHandler<Request, Response>
    {
        private readonly IMediator _mediator;
        private readonly IProdutoWriteRepository _produtoWriteRepository;
        private readonly IUnitOfWork _uow;

        public Handler(IMediator mediator, IProdutoWriteRepository produtoWriteRepository, IUnitOfWork uow)
        {
            _mediator = mediator;
            _produtoWriteRepository = produtoWriteRepository;
            _uow = uow;
        }

        public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            var produto = new Entities.Produto(request.Nome, request.PrecoUnitario, request.CategoriaId);
            _produtoWriteRepository.Add(produto);
            await _uow.CommitAsync();

            await _mediator.Publish(new Notification
            {
                Id = produto.Id,
                Nome = produto.Nome
            });

            return new Response(produto);
        }
    }
}
