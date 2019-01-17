using MediatR;
using System;

namespace FN.Store.Domain.Mediator.Produto.Excluir
{
    public class Notification : INotification
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataHora { get; set; } = DateTime.UtcNow;

        public override string ToString()
            => $"Produto {Nome} excluído com sucesso em {DataHora}";
    }
}
