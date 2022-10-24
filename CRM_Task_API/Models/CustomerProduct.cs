using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM_Task_API.Models
{
    public class CustomerProduct
    {
        public long Id { get; set; }

        [Required]
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product product { get; set; }

        [Required]
        public int customerId { get; set; }
        [ForeignKey("customerId")]
        public Customer customer { get; set; }
    }
}
