using Microsoft.AspNetCore.SignalR;
using Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetProvider.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message, string path)
        {
            var data = DateTime.UtcNow;
            await Clients.All.SendAsync("ReceiveMessage", user, message, data);

            var id = path.Remove(0, path.LastIndexOf('/') + 1);

            DbRepository db = new DbRepository();

            var review = new Review()
            {
                Id = Guid.NewGuid(),
                Content = message,
                ItemTypeId = new Guid(id),
                ReleaseDate = data,
                PersonalDataId = user
            };

            db.Create(review);
        }

    }
}
