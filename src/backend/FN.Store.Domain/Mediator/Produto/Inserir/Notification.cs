using MediatR;
using System;

namespace FN.Store.Domain.Mediator.Produto.Inserir
{
    public class Notification : INotification
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataHora { get; set; } = DateTime.UtcNow;

        public override string ToString()
            => $"Produto {Nome} inserido com sucesso em {DataHora}";
    }
}
