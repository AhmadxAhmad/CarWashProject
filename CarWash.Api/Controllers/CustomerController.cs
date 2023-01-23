using AutoMapper;
using CarWash.Api.Models;
using CarWash.Api.Repositories;
using CarWash.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CarWash.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepo;
        private readonly ILogger<CustomerController> _logger;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerRepository CustomerRepo, ILogger<CustomerController> logger, IMapper mapper)
        {
            _customerRepo = CustomerRepo;
            _logger = logger;
            _mapper = mapper;
            _logger.LogInformation("CustomerController status: OK");
        }
       
        [HttpPost("AddCustomer")]
        public async Task<IActionResult> AddCustomer(CustomerViewModel model)
        {
            if (ModelState.IsValid)
            {
                var CustomerToAdd = _mapper.Map<Customer>(model);
                var res = await _customerRepo.AddItem(CustomerToAdd);
                if (res == 0)
                {
                    if (await _customerRepo.SaveAsync())
                    {
                        return Ok(CustomerToAdd.CustomerId);
                    }
                    else return BadRequest(res);
                }
                else return Ok(res);
            }
            return BadRequest("Model is not Valid");
        }
        

    }
}
