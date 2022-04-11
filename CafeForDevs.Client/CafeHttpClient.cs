using CafeForDevs.Models;
using Newtonsoft.Json;
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

        public MenuDto GetMenu()
        {
            var response = _client.GetAsync("menu").Result;
            var json = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<MenuDto>(json);
        }

        public void SelectMenuItem(int menuItemId, int quantity)
        {
            var request = new MenuItemRequestDto
            {
                MenuItemId = menuItemId,
                Quantity = quantity
            };

            var json = JsonConvert.SerializeObject(request);
            var content = new StringContent(json);
            var response = _client.PostAsync("order", content).Result;
        }

        public OrderDto GetOrder()
        {
            var response = _client.GetAsync("order").Result;
            var json = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<OrderDto>(json);
        }
    }

}
