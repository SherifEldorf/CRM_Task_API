using System.Collections.Generic;
using System.Threading.Tasks;
using CRM_Task_API.Models;
using Microsoft.Extensions.Primitives;

namespace CRM_Task_API.Repository.User
{
    public interface IUserRepo
    {
        Task<IEnumerable<Product>> GetProductsasync();
        Task< Product > AddProductAsync( Product product );
        Task<Product> GetProductAsync(string id);
        Task<Product> EditProductAsync(Product model);

        Task<bool> DeleteProductsrAsync(List<string> ids);
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
        Task<Customer> AddCustomerAsync( Customer customer );
        Task<Customer> GetCustomerAsync(string id);
        Task<Customer> EditCustomerAsync(Customer model);
        Task<bool> DeleteAllCustomersAsync(List<string> ids);
        Task<IEnumerable<Order>> GetAllOrdersAsync();
        Task<bool> DeleteOrdersAsync(List<string> ids);
        Task<bool> AddOrderAsync(string customerId, string date, string shippingAddress, string pillingAddress, string subtotal, string tax, string status, List<int> ids);
    }
}
