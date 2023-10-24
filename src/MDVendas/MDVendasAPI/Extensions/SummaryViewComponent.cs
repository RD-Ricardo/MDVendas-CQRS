using MDVendas.Core.Messages.CommonMessages.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace MDVendasAPI.Extensions
{
    public class SummaryViewComponent : ViewComponent 
    {
        private readonly DomainNotificationHandler _domainNotificationHandler;
        public SummaryViewComponent(DomainNotificationHandler domainNotificationHandler)
        {
            _domainNotificationHandler = domainNotificationHandler;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var notificacoes = await Task.FromResult(_domainNotificationHandler.ObterNotificacoes());

            notificacoes.ForEach(x =>  ViewData.ModelState.AddModelError(string.Empty, x.Value));
            return View();
        }
    }
}
