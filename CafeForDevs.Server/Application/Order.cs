using System.Collections.Generic;

namespace CafeForDevs.Server.Application
{
    internal class Order
    {
        private List<OrderPosition> _positions;

        internal Order()
        {
            _positions = new List<OrderPosition>();
        }

        internal void AddPosition(MenuItem menuItem, int quantity)
        {
            var position = new OrderPosition
            {
                Name = menuItem.Name,
                Price = menuItem.Price,
                Quantity = quantity,
            };

            _positions.Add(position);
        }

        internal OrderPosition[] GetPositions()
        {
            return _positions.ToArray();
        }
    }
}
