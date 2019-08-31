using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SignalRBroker.Hubs
{
    public class BrokerHub : Hub
    {
        private readonly Random _rng;
        private decimal _price;

        public BrokerHub()
        {
            _rng = new Random();
            _price = 1000;
        }

        public async Task GetUpdatedPrice()
        {
            do
            {
                var timeToUpdate = _rng.Next(10);

                Thread.Sleep(timeToUpdate * 1000);

                var priceVariation = _rng.Next(100) - 50;

                _price += priceVariation;

                await Clients.All.SendAsync("ReceiveUpdatedPrice", new PriceResult() { Price = _price });
            } while (true);
        }

        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }
    }

    public class PriceResult
    {
        public decimal Price { get; set; }
    }
}