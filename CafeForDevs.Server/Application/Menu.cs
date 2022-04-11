
using System.Linq;

namespace CafeForDevs.Server.Application
{
    internal static class Menu
    {
        static Menu()
        {
            Items = new[]
            {
                new MenuItem
                {
                    Id = 1,
                    Name = "CheeseCake",
                    Price = 500
                },

                new MenuItem
                {
                    Id = 2,
                    Name = "AppleJuice",
                    Price = 200
                },

                new MenuItem
                {
                    Id = 3,
                    Name = "Coffee",
                    Price = 300
                }
            };
        }

        internal static MenuItem[] Items { get; set; }

        internal static MenuItem Get(int menuItemId)
        {
            return Items.SingleOrDefault(x => x.Id == menuItemId);
        }
    }
}
