using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRM_Task_API.Models;
using Microsoft.EntityFrameworkCore;

namespace CRM_Task_API.Repository.User
{
    public class UserRepository : IUserRepo
    {
        private readonly ApplicationDb _db;

        public UserRepository( ApplicationDb db)
        {
            _db = db;
        }

        public async Task<Customer> AddCustomerAsync(Customer customer)
        {
            if (customer == null)
            {
                return null;
            }
            Customer newCustomer = new Customer();
            newCustomer.FirstName = customer.FirstName;
            newCustomer.LastName = customer.LastName;
            newCustomer.Email = customer.Email;
            newCustomer.Phone = customer.Phone;
            newCustomer.Code = customer.Code;
            newCustomer.billingAddress = customer.billingAddress;
            newCustomer.AddressLine2 = customer.AddressLine2;
            newCustomer.Activeted = customer.Activeted;
            await _db.Customers.AddAsync(newCustomer);
            await _db.SaveChangesAsync();
            return newCustomer;
        }

        public async Task<Product> AddProductAsync(Product product)
        {
            if(product == null)
            {
                return null;
            }
            Product newProduct = new Product();
            newProduct.Name=product.Name;
            newProduct.Description=product.Description;
            newProduct.Price=product.Price;
            await _db.Products.AddAsync(newProduct);
            await _db.SaveChangesAsync();
            return newProduct;
        }

        public async Task<bool> DeleteProductsrAsync(List<string> ids)
        {
            if (ids.Count < 1)
            {
                return false;
            }

            var i = 0;
            foreach (var id in ids)
            {
                try
                {
                    var productId = int.Parse(id);
                    var Product = await _db.Products.FirstOrDefaultAsync(x => x.Id == productId);
                    if (Product != null)
                    {
                        _db.Products.Remove(Product);
                        i++;
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
            if (i > 0)
            {
                await _db.SaveChangesAsync();
            }
            return true;
        }

        public async Task<bool> DeleteAllCustomersAsync(List<string> ids)
        {
            if (ids.Count < 1)
            {
                return false;
            }

            var i = 0;
            foreach (var id in ids)
            {
                try
                {
                    var CustomerId = int.Parse(id);
                    var customer = await _db.Customers.FirstOrDefaultAsync(x => x.Id == CustomerId);
                    if (customer != null)
                    {
                        _db.Customers.Remove(customer);
                        i++;
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
            if (i > 0)
            {
                await _db.SaveChangesAsync();
            }
            return true;
        }
        public async Task<Product> EditProductAsync(Product model)
        {
            if (model == null || model.Id < 1)
            {
                return null;
            }

            var product = await _db.Products.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (product == null)
            {
                return null;
            }
            _db.Products.Attach(product);
            product.Name = model.Name;
            product.Price = model.Price;
            product.Description = model.Description;

            _db.Entry(product).Property(x => x.Name).IsModified = true;
            _db.Entry(product).Property(x => x.Price).IsModified = true;
            _db.Entry(product).Property(x => x.Description).IsModified = true;

            await _db.SaveChangesAsync();
            return product;
        }
        public async Task<bool> DeleteOrdersAsync(List<string> ids)
        {
            if (ids.Count < 1)
            {
                return false;
            }

            var i = 0;
            foreach (var id in ids)
            {
                try
                {
                    var orderId = int.Parse(id);
                    var order = await _db.Orders.FirstOrDefaultAsync(x => x.Id == orderId);
                    if (order != null)
                    {
                        _db.Orders.Remove(order);
                        i++;
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
            if (i > 0)
            {
                await _db.SaveChangesAsync();
            }
            return true;
        }
        public async Task<Customer> EditCustomerAsync(Customer model)
        {
            if (model == null || model.Id < 1)
            {
                return null;
            }

            var customer = await _db.Customers.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (customer == null)
            {
                return null;
            }
            _db.Customers.Attach(customer);
            customer.FirstName = model.FirstName;
            customer.LastName = model.LastName;
            customer.Phone=model.Phone;
            customer.Email=model.Email;
            customer.Code=model.Code;
            customer.Activeted = model.Activeted;
            customer.billingAddress = model.billingAddress;
            customer.AddressLine2 = model.AddressLine2;

            _db.Entry(customer).Property(x => x.FirstName).IsModified = true;
            _db.Entry(customer).Property(x => x.LastName).IsModified = true;
            _db.Entry(customer).Property(x => x.Activeted).IsModified = true;
            _db.Entry(customer).Property(x => x.Code).IsModified = true;
            _db.Entry(customer).Property(x => x.billingAddress).IsModified = true;
            _db.Entry(customer).Property(x => x.AddressLine2).IsModified = true;
            _db.Entry(customer).Property(x => x.Email).IsModified = true;
            _db.Entry(customer).Property(x => x.Phone).IsModified = true;


            await _db.SaveChangesAsync();
            return customer;
        }


        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            var customers = await _db.Customers.ToListAsync();
            return customers;
        }
        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await _db.Orders.OrderByDescending(x => x.Id).Include(y => y.Customer).ToListAsync();
        }

        public async Task<Product> GetProductAsync(string id)
        {
            if (id == null)
            {
                return null;
            }

            var product = await _db.Products.FirstOrDefaultAsync(x => x.Id ==int.Parse(id));
            if (product == null)
            {
                return null;
            }
            return product;
        }
        public async Task<Customer> GetCustomerAsync(string id)
        {
            if (id == null)
            {
                return null;
            }

            var customer = await _db.Customers.FirstOrDefaultAsync(x => x.Id == int.Parse(id));
            if (customer == null)
            {
                return null;
            }
            return customer;
        }
        public async Task<IEnumerable<Product>> GetProductsasync()
        {
            var products = await _db.Products.ToListAsync();
            return products;
        }

        public async Task<bool> AddOrderAsync(string customerId, string Date, string shippingAddress, string pillingAddress, string subtotal, string tax, string status, List<int> ids)
        {

            var order = new Order
            {
                Date =Date,
                ShippingAddress = shippingAddress,
                PillingAddress=pillingAddress,
                CustomerId= int.Parse(customerId),
                subtotal= int.Parse( subtotal), tax = int.Parse(tax) , Status = Boolean.Parse(status)

            };
            _db.Orders.Add(order);
            await _db.SaveChangesAsync();

            foreach (var id in ids)
            {
                var userorder = new CustomerProduct
                {
                    customerId=int.Parse(customerId),
                    ProductId = id
                };
                _db.CustomerProducts.Add(userorder);
                await _db.SaveChangesAsync();
            }




            return true;
        }
    }
}
