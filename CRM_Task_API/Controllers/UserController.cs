using System.Collections.Generic;
using System.Threading.Tasks;
using CRM_Task_API.Models;
using CRM_Task_API.Repository.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRM_Task_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepo _repo;

        public UserController(IUserRepo repo)
        {
            _repo = repo;
        }
        [Route("GetAllProducts")]
        [HttpGet]
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _repo.GetProductsasync();
        }
        [Route("AddProduct")]
        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                var newProduct = await _repo.AddProductAsync(product);
                if (newProduct != null)
                {
                    return Ok();
                }
            }
            return BadRequest();
        }
        [Route("GetProduct/{id}")]
        [HttpGet]
        public async Task<ActionResult<Product>> GetProduct(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var product = await _repo.GetProductAsync(id);
            if (product != null)
            {
                return product;
            }
            return BadRequest();
        }

        [Route("EditProduct")]
        [HttpPut]
        public async Task<ActionResult<Product>> EditProduct(Product model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var product = await _repo.EditProductAsync(model);
            if (product != null)
            {
                return product;
            }
            return BadRequest();
        }

        [Route("DeleteProducts")]
        [HttpPost]
        public async Task<IActionResult> DeleteProducts(List<string> ids)
        {
            if (ids.Count < 1)
            {
                return BadRequest();
            }

            var result = await _repo.DeleteProductsrAsync(ids);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }

        [Route("GetAllCustomers")]
        [HttpGet]
        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            return await _repo.GetAllCustomersAsync();
        }

        [Route("AddCustomer")]
        [HttpPost]
        public async Task<IActionResult> AddCustomer(Customer customer)
        {
            if (ModelState.IsValid)
            {
                var newCustomer = await _repo.AddCustomerAsync(customer);
                if (newCustomer != null)
                {
                    return Ok();
                }
            }
            return BadRequest();
        }
        [Route("GetCustomer/{id}")]
        [HttpGet]
        public async Task<ActionResult<Customer>> GetCustomer(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var customer = await _repo.GetCustomerAsync(id);
            if (customer != null)
            {
                return customer;
            }
            return BadRequest();
        }
        [Route("EditCustomer")]
        [HttpPut]
        public async Task<ActionResult<Customer>> EditCustomer(Customer model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var customer = await _repo.EditCustomerAsync(model);
            if (customer != null)
            {
                return customer;
            }
            return BadRequest();
        }

        [Route("DeleteAllCustomers")]
        [HttpPost]
        public async Task<IActionResult> DeleteAllCustomers(List<string> ids)
        {
            if (ids.Count < 1)
            {
                return BadRequest();
            }

            var result = await _repo.DeleteAllCustomersAsync(ids);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }
        [Route("GetAllOrders")]
        [HttpGet]
        public async Task<IEnumerable<Order>> GetAllOrders()
        {
            return await _repo.GetAllOrdersAsync();
        }
        [Route("AddOrder")]
        [HttpPost]
        public async Task<IActionResult> AddOrder()
        {

            var customerId = HttpContext.Request.Form["customerId"].ToString();
            var Date = HttpContext.Request.Form["Date"].ToString();
            var subtotal = HttpContext.Request.Form["subtotal"].ToString();
            var tax = HttpContext.Request.Form["tax"].ToString();
            var shippingAddress = HttpContext.Request.Form["shippingAddress"].ToString();
            var pillingAddress = HttpContext.Request.Form["pillingAddress"].ToString();
            var productId = HttpContext.Request.Form["productId[]"].ToArray();
            var status = HttpContext.Request.Form["status"].ToString();
            List<int> ids = new List<int>();
            for (int i = 0; i < productId.Length; i++)
            {
                var result = int.TryParse(productId[i], out int id);
                if (result)
                    ids.Add(id);
            }
            if (ids.Count < 1)
            {
                return NoContent();
            }
            if (!string.IsNullOrEmpty(customerId) && !string.IsNullOrEmpty(Date)
                && !string.IsNullOrEmpty(shippingAddress) && !string.IsNullOrEmpty(pillingAddress) && !
               string.IsNullOrEmpty(subtotal) && !string.IsNullOrEmpty(tax) && ids.Count > 0)
            {
                var result = await _repo.AddOrderAsync(customerId, Date, shippingAddress, pillingAddress, subtotal, tax, status, ids);
                if (result)
                {
                    return Ok();
                }
            }
            return BadRequest();


        }

        [Route("DeleteAllOrders")]
        [HttpPost]
        public async Task<IActionResult> DeleteAllOrders(List<string> ids)
        {
            if (ids.Count < 1)
            {
                return BadRequest();
            }

            var result = await _repo.DeleteOrdersAsync(ids);
            if (result)
            {
                return Ok();
            }
            return BadRequest();

        }
    }
}
