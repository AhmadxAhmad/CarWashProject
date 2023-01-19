using DataProvider;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace CarWash.Api.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly DatabaseContext context;
        public TestController(DatabaseContext context)
        {
            this.context = context;
            context.Database.EnsureCreated();
        }
        [HttpPost(Name ="/cat")]
        public IActionResult NewCat(Category category)
        {

            context.Categories.Add(category);
            var x=context.SaveChanges();
            if (x >= 1)
            {
                return Ok();

            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPost(Name = "/Product")]
        public IActionResult NewProduct(Product Product)
        {

            context.Products.Add(Product);
            var x = context.SaveChanges();
            if (x >= 1)
            {
                return Ok();

            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPost(Name = "/Customer")]
        public IActionResult NewCustomer(Customer Customer)
        {

            context.Customers.Add(Customer);
            var x = context.SaveChanges();
            if (x >= 1)
            {
                return Ok();

            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPost(Name = "/Order")]
        public IActionResult NewOrder(Order Order)
        {
            context.Orders.Add(Order);
            var x = context.SaveChanges();
            if (x >= 1)
            {
                return Ok();

            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPost(Name = "/Receipt")]
        public IActionResult NewReceipt(Receipt Receipt)
        {
            context.Receipts.Add(Receipt);
            var x = context.SaveChanges();
            if (x >= 1)
            {
                return Ok();

            }
            else
            {
                return BadRequest();
            }
        }
    }
}
