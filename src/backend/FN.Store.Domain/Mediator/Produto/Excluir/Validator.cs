using FluentValidation;

namespace FN.Store.Domain.Mediator.Produto.Excluir
{
    public class Validator : AbstractValidator<Request>
    {
        public Validator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id é obrigatório");
        }
    }
}
