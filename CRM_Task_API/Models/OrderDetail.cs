using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM_Task_API.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        [Required]
        public int LineNo { get; set; }
        [Required]
        
        

        public int price { get; set; }
        [Required]

        public int orderedQty { get; set; }
        [Required]

        public int TaxAmount { get; set; }
        [Required]

        public int total { get; set; }
        public int CustomerId { get; set; }

        [ForeignKey("CustomerId")]
         public Customer Customer { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
    }
}
