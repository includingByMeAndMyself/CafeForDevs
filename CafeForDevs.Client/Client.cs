using System;
using System.Linq;

namespace CafeForDevs.Client
{
    internal partial class Client
    {
        private ICafeHttpClient _cafeHttpClient;

        public Client(ICafeHttpClient cafeHttpClient)
        {
            _cafeHttpClient = cafeHttpClient;
        }

        internal void Start()
        {
            Console.WriteLine("Client started");

            var isUserContinue = true;
            string userAnswer;

            do
            {
                Console.WriteLine("Select a menu item:" +
                    "\n\t1) Select restaurant menu" +
                    "\n\t2) Choose a dish from the menu" +
                    "\n\t3) Pay for the order" +
                    "\n\t4) Display information about your order");


                userAnswer = Console.ReadLine();

                switch (userAnswer)
                {
                    case "1": break;
                    case "2": break;
                    case "3": break;
                    case "4": break;
                }

                Console.WriteLine("Continue? (y/n)");
                userAnswer = Console.ReadLine();

                isUserContinue = userAnswer.ToLower() == "y";


            } while (isUserContinue);
        }

        public void GetMenu()
        {
            var menu = _cafeHttpClient.GetMenu();

            foreach (var item in menu.Items)
            {
                Console.WriteLine($"№{item.Id}: {item.Name} - {item.Price}");
            }
        }

        public void SelectMenuItem()
        {
            Console.WriteLine("Введите номер блюда");
            var userAnser = Console.ReadLine();
            var menuItemId = int.Parse(userAnser);

            _cafeHttpClient.SelectMenuItem(menuItemId);
        }

        public void GetOrder()
        {
            var order = _cafeHttpClient.GetOrder();

            foreach (var item in order.Positions)
            {
                Console.WriteLine($"{item.Name}: {item.Price} * {item.Quantity} = {item.Sum}");
            }

            var orderTotal = order.Positions.Sum(x => x.Sum);

            Console.WriteLine($"Сумма вашего заказа: {orderTotal}");
        }

    }
}
