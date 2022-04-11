using CafeForDevs.Models;
using CafeForDevs.Server.Application;
using System.Linq;
using System.Net;

namespace CafeForDevs.Server.Handlers
{
    public class OrderHandler : Handler, IHandler
    {
        private Order _order;

        public OrderHandler()
        {
            _order = new Order();
        }

        public string Path => "/order";

        public void Handle(HttpListenerContext context)
        {
            switch (context.Request.HttpMethod)
            {
                case "POST":

                    var request = GetRequestBody<MenuItemRequestDto>(context);

                    SelectMenuItem(request.MenuItemId, request.Quantity);

                    context.Response.StatusCode = (int)HttpStatusCode.OK;
                    break;
                case "GET":
                    var order = GetOrder();
                    SetResponse(order, context);

                    context.Response.StatusCode = (int)HttpStatusCode.OK;
                    break;
            }

            context.Response.Close();
        }

        private OrderDto GetOrder()
        {
            var order = new OrderDto
            {
                Positions = _order.GetPositions()
                .Select(x => new OrderPositionDto
                {
                    Name = x.Name,
                    Price = x.Price,
                    Quantity = x.Quantity
                })
                .ToArray()
            };

            return order;
        }

        private void SelectMenuItem(int menuItemId, int quantity)
        {
            var menuItem = Menu.Get(menuItemId);

            _order.AddPosition(menuItem, quantity);
        }
    }
}
