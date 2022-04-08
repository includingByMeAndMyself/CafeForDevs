using System;
using System.Net.Http;

namespace CafeForDevs.Client
{
    public class CafeHttpClient : ICafeHttpClient
    {
        private readonly HttpClient _client;

        public CafeHttpClient(HttpClient client, Uri baseUri)
        {
            _client = client;
            _client.BaseAddress = baseUri;
        }

        public Menu GetMenu()
        {
            var response = _client.GetAsync("");

            return new Menu();
        }

        public void SelectMenuItem(int menuItemId)
        {
            var content = menuItemId;

            var response = _client.PostAsync("", content);
        }

        public Order GetOrder()
        {
            var response = _client.GetAsync("");

            return new Order();
        }
    }

}
