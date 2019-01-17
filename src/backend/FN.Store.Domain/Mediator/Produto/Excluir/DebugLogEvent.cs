using MediatR;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace FN.Store.Domain.Mediator.Produto.Excluir
{
    public class DebugLogEvent : INotificationHandler<Notification>
    {
        public async Task Handle(Notification notification, CancellationToken cancellationToken)
        {
            await Task.Run(() =>
            {
                Debug.WriteLine(notification.ToString());
            });
        }

    }
}
