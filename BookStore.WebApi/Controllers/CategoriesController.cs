using AutoMapper;
using BookStore.BusinessLayer.Abstract;
using BookStore.EntityLayer.Concrete;
using BookStore.WebApi.Dtos.Category;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult CategoryList()
        {
            var categories = _categoryService.TGetAll();
            var values = _mapper.Map<List<CategoryResultDto>>(categories);
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateCategory(CategoryCreateDto category)
        {
            var value = _mapper.Map<Category>(category);
            _categoryService.TAdd(value);
            return Ok("Ekleme işlemi başarı ile gerçekleştirildi.");
        }

        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            _categoryService.TDelete(id);
            return Ok("Silme işlemi başarı ile gerçekleştirildi.");
        }

        [HttpPut]
        public IActionResult UpdateCategory(CategoryUpdateDto category)
        {
            var value = _mapper.Map<Category>(category);
            _categoryService.TUpdate(value);
            return Ok("Güncelleme işlemi başarı ile gerçekleştirildi.");
        }

        [HttpGet("GetByIdCategory")]
        public IActionResult GetCategory(int id)
        {
            var value = _categoryService.TGetById(id);
            var result = _mapper.Map<CategoryGetByIdDto>(value);

            return Ok(result);
        }
    }
}

