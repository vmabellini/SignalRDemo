using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using SignalRBroker.Hubs;

namespace SignalRBroker.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IHubContext<BrokerHub> _hubContext;

        public IndexModel(IHubContext<BrokerHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public void OnGet()
        {
        }
    }
}