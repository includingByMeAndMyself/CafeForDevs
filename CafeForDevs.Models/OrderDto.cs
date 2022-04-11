namespace CafeForDevs.Models
{

    public class OrderDto
    {
        public OrderPositionDto[] Positions { get; set; }
        public decimal Sum { get; set; }
    }

}
