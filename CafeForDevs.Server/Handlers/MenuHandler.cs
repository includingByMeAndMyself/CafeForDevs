using CafeForDevs.Models;
using CafeForDevs.Server.Application;
using System.Linq;
using System.Net;


namespace CafeForDevs.Server.Handlers
{
    public class MenuHandler : Handler, IHandler
    {
        public string Path => "/menu";

        public void Handle(HttpListenerContext context)
        {
            switch (context.Request.HttpMethod)
            {
                case "GET":
                    var menu = GetMenu();
                    context.Response.StatusCode = (int)HttpStatusCode.OK;

                    SetResponse(menu, context);
                    break;
            }
            context.Response.Close();
        }

        private MenuDto GetMenu()
        {
            var menu = new MenuDto
            {
                Items = Menu.Items
                    .Select(x => new MenuItemDto
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Price = x.Price
                    }).ToArray()
            };

            return menu;
        }
    }
}
