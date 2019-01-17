using FN.Store.Api.ViewModels;
using FN.Store.Domain.Contracts.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace FN.Store.Api.Controllers
{
    [Route("api/v1/produtos")]
    public class ProdutosController: Controller
    {
        private readonly IProdutoReadRepository _produtoReadRepository;
        private readonly IMediator _mediator;
        public ProdutosController(IProdutoReadRepository produtoReadRepository, IMediator mediator)
        {
            _produtoReadRepository = produtoReadRepository;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _produtoReadRepository.GetAsync();
            return Ok(data);
        }


        [HttpGet("{id:int}", Name = "GetProdutoById")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _produtoReadRepository.GetAsync(id);

            if (data == null)
                return NotFound();

            return Ok(data);
        }

        [HttpGet("{skip}/{take:int=10}")]
        public async Task<IActionResult> Get(int skip, int take)
        {
            var data = await _produtoReadRepository.GetAsync(skip, take);
            return Ok(new Pagination(_produtoReadRepository.Total, data));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Domain.Mediator.Produto.Inserir.Request request)
        {
            var response = await _mediator.Send(request).ConfigureAwait(false);

            if (response.Errors.Any())
            {
                return BadRequest(response.Errors);
            }

            return CreatedAtRoute("GetProdutoById", new { id = response.Result.Id }, response.Result);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, [FromBody]Domain.Mediator.Produto.Atualizar.Request request)
        {
            request.Id = id;

            var response = await _mediator.Send(request).ConfigureAwait(false);

            if (response.Errors.Any())
            {
                return BadRequest(response.Errors);
            }

            return NoContent();
        }

         [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var request = new Domain.Mediator.Produto.Excluir.Request();
            request.Id = id;

            var response = await _mediator.Send(request).ConfigureAwait(false);

            if (response.Errors.Any())
            {
                return BadRequest(response.Errors);
            }

            return NoContent();
        }
    }
}
