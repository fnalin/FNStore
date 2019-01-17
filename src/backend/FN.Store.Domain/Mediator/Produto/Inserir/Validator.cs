using FluentValidation;

namespace FN.Store.Domain.Mediator.Produto.Inserir
{
    public class Validator : AbstractValidator<Request>
    {

        public Validator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("Nome é obrigatório")
                .Length(1, 80).WithMessage("Nome não pode ser maior que 80 caracteres");


            RuleFor(x => x.PrecoUnitario)
                .NotEmpty().WithMessage("PrecoUnitario é obrigatório");


            RuleFor(x => x.CategoriaId)
                .NotEmpty().WithMessage("Categoria é obrigatório");

            

        }
    }
}
