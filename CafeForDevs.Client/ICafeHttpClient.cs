using CafeForDevs.Models;

namespace CafeForDevs.Client
{
    public interface ICafeHttpClient
    {
        MenuDto GetMenu();
        void SelectMenuItem(int menuItemId, int quantity);
        OrderDto GetOrder();

    }
}