using MentorMate.Restaurant.Domain.Consts;
using System.ComponentModel.DataAnnotations;

namespace MentorMate.Restaurant.Domain.Models.Orders
{
    public class CreateOrderModel
    {
        [Required(ErrorMessage = Messages.OrderTableIdRequired)]
        public int TableId { get; set; }
        public ICollection<int> ProductIds { get; set; }
    }
}
