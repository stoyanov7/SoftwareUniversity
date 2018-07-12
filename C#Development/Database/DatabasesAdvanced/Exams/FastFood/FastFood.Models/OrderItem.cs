namespace FastFood.Models
{
    using System.ComponentModel.DataAnnotations;

    public class OrderItem
    {
        [Required]
        public int OrderId { get; set; }
        [Required]
        public Order Order { get; set; }

        [Required]
        public int ItemId { get; set; }
        [Required]
        public Item Item { get; set; }

        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }
    }
}