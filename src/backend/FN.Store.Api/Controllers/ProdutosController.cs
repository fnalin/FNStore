using FN.Store.Api.Controllers.ViewModels;
using FN.Store.Domain.Contracts.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FN.Store.Api.Controllers
{
    [Route("api/v1/produtos")]
    public class ProdutosController: Controller
    {
        private readonly IProdutoReadRepository _produtoReadRepository;
        public ProdutosController(IProdutoReadRepository produtoReadRepository)
        {
            _produtoReadRepository = produtoReadRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _produtoReadRepository.GetAsync();
            return Ok(data);
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
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
    }
}
