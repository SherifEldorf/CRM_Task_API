using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM_Task_API.Models
{
    public class Order
    {

        public int Id { get; set; }
        [Required]
        public bool Status { get; set; }
        [Required]
        public string Date { get; set; }
        [Required]
        public int tax { get; set; }
        [Required]
        public int subtotal { get; set; }
        public int GrandTotal { get; set; } 
        [Required]
        public string ShippingAddress { get; set; }
        [Required]
        public string PillingAddress { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

    }
}
