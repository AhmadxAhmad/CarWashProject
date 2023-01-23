using AutoMapper;
using CarWash.Api.Models;
using CarWash.Api.Repositories;
using CarWash.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CarWash.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepo;
        private readonly ILogger<CustomerController> _logger;
        private readonly IMapper _mapper;

        public OrderController(IOrderRepository OrderRepo, ILogger<CustomerController> logger, IMapper mapper)
        {
            _orderRepo = OrderRepo;
            _logger = logger;
            _mapper = mapper;
            _logger.LogInformation("CustomerController status: OK");
        }
       
        [HttpPost("AddOrder")]
        public async Task<IActionResult> AddOrderr(OrderViewModel model)
        {
            if (ModelState.IsValid)
            {
                var CustomerToAdd = _mapper.Map<Order>(model);
                var res = await _orderRepo.AddItem(CustomerToAdd);
                var SaveRes = await _orderRepo.SaveAsync();
                if (SaveRes) return Ok(SaveRes);
                else return BadRequest(res);
            }
            return BadRequest("Model is not Valid");
        }
        [HttpGet("CheckBookingId/{bId}")]
        public async Task<IActionResult> CheckBookingId(string bId)
        {
           
                var IsExist = await _orderRepo.CheckBookingId(bId);

                if (IsExist) return BadRequest(IsExist);
                else return Ok(IsExist);

        }


    }
}
