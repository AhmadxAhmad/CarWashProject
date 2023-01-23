using AutoMapper;
using CarWash.Api.Models;
using CarWash.Api.Repositories;
using CarWash.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CarWash.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _catRepo;
        private readonly ILogger<CategoryController> _logger;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryRepository CatRepo, ILogger<CategoryController> logger,IMapper mapper)
        {
            _catRepo = CatRepo;
            _logger = logger;
            _mapper = mapper;
            _logger.LogInformation("CategoryController status: OK");
        }
        [HttpGet("GetAllCategories")]
        public async Task<IActionResult> GetAllCategories()
        {
           var res=  await _catRepo.GetAll();
            if (res != null && res.Any())
            {
                var CategoriesToReturn= _mapper.Map<IEnumerable<CategoryViewModel>>(res); 
                return Ok(CategoriesToReturn);
            }
            return NoContent();
        }
        //[HttpGet("GetCategoryById/{id:int}")]
        //public async Task<IActionResult> GetCategoryById(int id)
        //{
        //    var res = await _catRepo.GetById(id);
        //    if (res is not null)
        //    {
        //        var CategoryToReturn= _mapper.Map<CategoryViewModel>(res);
        //        return Ok(CategoryToReturn);
        //    }
        //    return NoContent();
        //}
        //[HttpGet("GetCategoryByTitle/{title}")]
        //public async Task<IActionResult> GetCategoryByTitle(string title)
        //{
        //    var res = await _catRepo.GetByTitle(title);
        //    if (res is not null)
        //    {
        //        var CategoryToReturn = _mapper.Map<CategoryViewModel>(res);
        //        return Ok(CategoryToReturn);
        //    }
        //    return NoContent();
        //}
        [HttpPost("AddCategory")]
        public async Task<IActionResult> AddCategory(CategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var CategoryToAdd = _mapper.Map<Category>(model);
                var res = await _catRepo.AddItem(CategoryToAdd);

                if (await _catRepo.SaveAsync()) return Ok(res);
                else return BadRequest(res);
            }
            return BadRequest("Model is not Valid");
        }
        [HttpDelete("DeleteCategoryById/{id:int}")]
        public async Task<IActionResult> DeleteCategoryById(int id)
        {
            var CategoryToDelete = await _catRepo.GetById(id);
            if (CategoryToDelete != null)
            {
                await _catRepo.RemoveItem(CategoryToDelete);
                if (await _catRepo.SaveAsync()) return Ok("Deleted");
            }
            return NotFound();
        }

        [HttpPut("UpdateCategory")]
        public async Task<IActionResult> UpdateCategory(CategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var CategoryToUpdate = await _catRepo.GetById(model.CategoryId);
                if (CategoryToUpdate != null)
                {
                    _mapper.Map(model, CategoryToUpdate);
                    if (await _catRepo.SaveAsync()) return Ok("Updated");
                }
            }
            return BadRequest("Model is not Valid");
        }

    }
}
