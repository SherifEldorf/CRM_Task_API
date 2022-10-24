using System.ComponentModel.DataAnnotations;

namespace CRM_Task_API.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]

        public string LastName { get; set; }
        [Required]

        public string Email { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]

        public string Phone { get; set; }
        [Required]
        public string billingAddress { get; set; }
        [Required]
        public string AddressLine2 { get; set; }
        public bool Activeted { get; set; }
    }
}
