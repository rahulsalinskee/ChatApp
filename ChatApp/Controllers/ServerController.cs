using ChatApp.Hubs;
using ChatApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace ChatApp.Controllers
{
    public class ServerController : Controller
    {
        private readonly IHubContext<NotificationHub> _notificationHubContext;

        public ServerController(IHubContext<NotificationHub> notificationHubContext)
        {
            this._notificationHubContext = notificationHubContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Index(Notification notificationModel)
        {
            /* Receive Notification Message is used from client to get the message */
            await this._notificationHubContext.Clients.All.SendAsync("ReceiveServerNotification", notificationModel.Message);
            return View();
        }
    }
}
