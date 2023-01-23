using AutoMapper;
using CarWash.Api.Models;
using CarWash.Api.Repositories;
using CarWash.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CarWash.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _prodRepo;
        private readonly ILogger<ProductController> _logger;
        private readonly IMapper _mapper;
        private readonly InfoRepository _infoRepository;

        public ProductController(IProductRepository ProdRepo, ILogger<ProductController> logger, IMapper mapper, InfoRepository infoRepository)
        {
            _prodRepo = ProdRepo;
            _logger = logger;
            _mapper = mapper;
            this._infoRepository = infoRepository;
            _logger.LogInformation("ProductController status: OK");
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
           var res=  await _prodRepo.GetAll();
            if(res !=null && res.Any())
            {
                return Ok(res);
            }
            return NotFound();
        }
        [HttpGet("GetProductById/{id:int}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var res = await _prodRepo.GetById(id);
            if (res is not null)
            {
                var ProductToReturn = _mapper.Map<ProductViewModel>(res);
                ProductToReturn.CategoryName = await _infoRepository.GetCategoryName(res.CategoryId);
                return Ok(ProductToReturn);
            }
            return NoContent();
        }
       
        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProduct(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                var ProductToAdd = _mapper.Map<Product>(model);
                var res = await _prodRepo.AddItem(ProductToAdd);

                if (await _prodRepo.SaveAsync()) return Ok(res);
                else return BadRequest(res);
            }
            return BadRequest("Model is not Valid");
        }
        [HttpDelete("DeleteProductById/{id:int}")]
        public async Task<IActionResult> DeleteProductById(int id)
        {
            var ProductToDelete = await _prodRepo.GetById(id);
            if (ProductToDelete != null)
            {
                await _prodRepo.RemoveItem(ProductToDelete);
                if (await _prodRepo.SaveAsync()) return Ok("Deleted");
            }
            return NotFound();
        }
     
        [HttpPut("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                var ProductToUpdate = await _prodRepo.GetById(model.ProductId);
                if (ProductToUpdate != null)
                {
                    //be aware 
                    //because it will override all proprty that you does not entered to null.
                    _mapper.Map(model, ProductToUpdate);



                    if (await _prodRepo.SaveAsync()) return Ok("Updated");
                }
                else return NotFound();
            }
            return BadRequest("Model is not Valid");
        }
    }
}
