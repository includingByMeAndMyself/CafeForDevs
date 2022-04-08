namespace CafeForDevs.Client
{

    public class Order
    {
        public OrderPosition[] Positions { get; set; }
        public decimal Sum { get; set; }
    }

}
